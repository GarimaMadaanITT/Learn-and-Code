using FinanceTracker.Domain.Dtos;

namespace FinanceTracker.Application.Interfaces
{
    public interface IBudgetService
    {
        BudgetDetailsDto SetBudget(CreateBudgetDto request);
        IReadOnlyCollection<BudgetDetailsDto> GetBudgets(BudgetFilterDto filter);
    }
}
