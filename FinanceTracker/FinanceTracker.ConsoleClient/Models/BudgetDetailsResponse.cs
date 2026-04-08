namespace FinanceTracker.ConsoleClient.Models
{
    public sealed class BudgetDetailsResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Limit { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Spent { get; set; }
        public bool IsExceeded { get; set; }
    }
}
