namespace FinanceTracker.Domain.Dtos
{
    public sealed class MonthlySummaryQueryDto
    {
        public Guid UserId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
