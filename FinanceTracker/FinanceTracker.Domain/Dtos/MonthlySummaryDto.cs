namespace FinanceTracker.Domain.Dtos
{
    public sealed class MonthlySummaryDto
    {
        public int Year { get; init; }
        public int Month { get; init; }
        public decimal TotalIncome { get; init; }
        public decimal TotalExpense { get; init; }
        public decimal Savings { get; init; }
    }
}
