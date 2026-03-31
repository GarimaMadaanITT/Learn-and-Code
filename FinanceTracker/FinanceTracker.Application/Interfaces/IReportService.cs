using FinanceTracker.Domain.Dtos;

namespace FinanceTracker.Application.Interfaces
{
    public interface IReportService
    {
        MonthlySummaryDto GetSummary(MonthlySummaryQueryDto query);
    }
}
