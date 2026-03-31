namespace FinanceTracker.ConsoleClient.Models
{
    public sealed class MonthlySummaryResponse
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Savings { get; set; }
    }
}
