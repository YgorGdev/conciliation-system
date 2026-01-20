using Conciliation.Application.Abstractions;

namespace Conciliation.Application.UseCases.ConciliatePayment;

public class ConciliatePaymentUseCase
{
    private readonly IConciliationRepository _repo;

    public ConciliatePaymentUseCase(IConciliationRepository repo)
    {
        _repo = repo;
    }

    public async Task<ConciliatePaymentResult> ExecuteAsync(Guid correlationId, CancellationToken ct)
    {
        var payment = await _repo.GetPaymentByCorrelationIdAsync(correlationId, ct);
        if (payment is null)
            return ConciliatePaymentResult.NotFound("Payment not found for this CorrelationId");

        var providerTx = await _repo.GetProviderTransactionByCorrelationIdAsync(correlationId, ct);
        if (providerTx is null)
            return ConciliatePaymentResult.NotFound("ProviderTransaction not found for this CorrelationId");

        if (payment.Amount == providerTx.Amount)
            payment.MarkConciliated();
        else
            payment.MarkDivergent();

        await _repo.SaveChangesAsync(ct);

        return ConciliatePaymentResult.Ok(
            correlationId,
            payment.Id,
            providerTx.Id,
            payment.Amount,
            providerTx.Amount,
            payment.Status
        );
    }
}

public record ConciliatePaymentResult(
    bool Success,
    int StatusCode,
    string? Error,
    Guid? CorrelationId,
    Guid? PaymentId,
    Guid? ProviderTransactionId,
    decimal? ExpectedAmount,
    decimal? ReceivedAmount,
    string? Result
)
{
    public static ConciliatePaymentResult Ok(Guid correlationId, Guid paymentId, Guid providerTxId, decimal expected, decimal received, string result)
        => new(true, 200, null, correlationId, paymentId, providerTxId, expected, received, result);

    public static ConciliatePaymentResult NotFound(string error)
        => new(false, 404, error, null, null, null, null, null, null);
}
