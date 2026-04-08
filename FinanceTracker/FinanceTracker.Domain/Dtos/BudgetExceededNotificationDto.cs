namespace FinanceTracker.Domain.Dtos
{
    public sealed class BudgetExceededNotificationDto
    {
        public Guid UserId { get; init; }
        public string Category { get; init; } = string.Empty;
        public int Year { get; init; }
        public int Month { get; init; }
        public decimal Limit { get; init; }
        public decimal Spent { get; init; }
    }
}
