using Conciliation.Domain.Entities;
using Conciliation.Infrastructure;
using Conciliation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration).WriteTo.Console());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sql = builder.Configuration.GetConnectionString("SqlServer")!;
builder.Services.AddInfrastructure(sql);

builder.Services.AddScoped<Conciliation.Application.UseCases.ConciliatePayment.ConciliatePaymentUseCase>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// -------------------- Payments (interno) --------------------
app.MapPost("/payments", async (CreatePaymentRequest req, AppDbContext db, CancellationToken ct) =>
{
    if (req.Amount <= 0)
        return Results.BadRequest(new { error = "Amount must be > 0" });

    var payment = new Payment(req.Amount, req.Currency ?? "BRL");
    db.Payments.Add(payment);
    await db.SaveChangesAsync(ct);

    return Results.Created($"/payments/{payment.Id}", new
    {
        payment.Id,
        payment.CorrelationId,
        payment.Amount,
        payment.Currency,
        payment.Status,
        payment.CreatedAtUtc
    });
});

app.MapGet("/payments/{id:guid}", async (Guid id, AppDbContext db, CancellationToken ct) =>
{
    var payment = await db.Payments.FirstOrDefaultAsync(x => x.Id == id, ct);
    return payment is null ? Results.NotFound() : Results.Ok(payment);
});

// -------------------- Provider Transactions (gateway/provedor) --------------------
app.MapPost("/provider/transactions", async (CreateProviderRequest req, AppDbContext db, CancellationToken ct) =>
{
    if (req.Amount <= 0)
        return Results.BadRequest(new { error = "Amount must be > 0" });

    var tx = new ProviderTransaction(req.CorrelationId, req.Amount, req.Provider);

    db.ProviderTransactions.Add(tx);
    await db.SaveChangesAsync(ct);

    return Results.Created($"/provider/transactions/{tx.Id}", new
    {
        tx.Id,
        tx.CorrelationId,
        tx.Amount,
        tx.ProviderName,
        tx.CreatedAtUtc
    });
});

// -------------------- Conciliação --------------------
app.MapPost("/conciliation/run/{correlationId:guid}", async (
    Guid correlationId,
    Conciliation.Application.UseCases.ConciliatePayment.ConciliatePaymentUseCase useCase,
    CancellationToken ct) =>
{
    var result = await useCase.ExecuteAsync(correlationId, ct);

    if (!result.Success)
        return Results.Problem(statusCode: result.StatusCode, title: result.Error);

    return Results.Ok(new
    {
        correlationId = result.CorrelationId,
        paymentId = result.PaymentId,
        providerTransactionId = result.ProviderTransactionId,
        expectedAmount = result.ExpectedAmount,
        receivedAmount = result.ReceivedAmount,
        result = result.Result
    });
});


app.Run();

record CreatePaymentRequest(decimal Amount, string? Currency);
record CreateProviderRequest(Guid CorrelationId, decimal Amount, string Provider);
