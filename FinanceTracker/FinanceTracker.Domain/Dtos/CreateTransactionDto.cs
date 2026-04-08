using FinanceTracker.Domain.Enum;

namespace FinanceTracker.Domain.Dtos
{
    public sealed class CreateTransactionDto
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
    }
}
