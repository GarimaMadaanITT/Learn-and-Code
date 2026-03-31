namespace FinanceTracker.Domain.Dtos
{
    public sealed class BudgetDetailsDto
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public string Category { get; init; } = string.Empty;
        public decimal Limit { get; init; }
        public int Year { get; init; }
        public int Month { get; init; }
        public decimal Spent { get; init; }
        public bool IsExceeded { get; init; }
    }
}
