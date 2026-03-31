namespace FinanceTracker.Domain.Dtos
{
    public sealed class TransactionFilterDto
    {
        public Guid UserId { get; set; }
        public DateTime? Date { get; set; }
        public string? Category { get; set; }
    }
}
