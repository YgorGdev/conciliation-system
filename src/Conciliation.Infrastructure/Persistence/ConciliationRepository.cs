using Conciliation.Application.Abstractions;
using Conciliation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Conciliation.Infrastructure.Persistence;

public class ConciliationRepository : IConciliationRepository
{
    private readonly AppDbContext _db;

    public ConciliationRepository(AppDbContext db)
    {
        _db = db;
    }

    public Task<Payment?> GetPaymentByCorrelationIdAsync(Guid correlationId, CancellationToken ct) =>
        _db.Payments.FirstOrDefaultAsync(x => x.CorrelationId == correlationId, ct);

    public Task<ProviderTransaction?> GetProviderTransactionByCorrelationIdAsync(Guid correlationId, CancellationToken ct) =>
        _db.ProviderTransactions.FirstOrDefaultAsync(x => x.CorrelationId == correlationId, ct);

    public Task SaveChangesAsync(CancellationToken ct) =>
        _db.SaveChangesAsync(ct);
}
