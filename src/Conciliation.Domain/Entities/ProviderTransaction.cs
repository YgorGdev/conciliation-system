namespace Conciliation.Domain.Entities;

public class ProviderTransaction
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CorrelationId { get; private set; }

    public decimal Amount { get; private set; }
    public string ProviderName { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    private ProviderTransaction() { }

    public ProviderTransaction(Guid correlationId, decimal amount, string provider)
    {
        CorrelationId = correlationId;
        Amount = amount;
        ProviderName = provider;
    }
}
