using Conciliation.Domain.Entities;

namespace Conciliation.Application.Abstractions;

public interface IConciliationRepository
{
    Task<Payment?> GetPaymentByCorrelationIdAsync(Guid correlationId, CancellationToken ct);
    Task<ProviderTransaction?> GetProviderTransactionByCorrelationIdAsync(Guid correlationId, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}
