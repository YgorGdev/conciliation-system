namespace Conciliation.Domain.Entities;

public class Payment
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CorrelationId { get; private set; } = Guid.NewGuid();

    public decimal Amount { get; private set; }
    public string Currency { get; private set; } = "BRL";
    public string Status { get; private set; } = "Pending";
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;

    private Payment() { }

    public Payment(decimal amount, string currency = "BRL")
    {
        if (amount <= 0) throw new ArgumentException("Amount must be > 0");
        Amount = amount;
        Currency = currency;
        
    }   
    public void MarkConciliated() => Status = "Conciliated";
    public void MarkDivergent() => Status = "Divergent";

}
