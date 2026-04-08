using FinanceTracker.Domain.Enum;

namespace FinanceTracker.Domain.Dtos
{
    public sealed class TransactionDetailsDto
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public decimal Amount { get; init; }
        public string Category { get; init; } = string.Empty;
        public TransactionType Type { get; init; }
        public DateTime Date { get; init; }
    }
}
