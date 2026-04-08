namespace FinanceTracker.ConsoleClient.Models
{
    public sealed class CreateBudgetRequest
    {
        public Guid UserId { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Limit { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
