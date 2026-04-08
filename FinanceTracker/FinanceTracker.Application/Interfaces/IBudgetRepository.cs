using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Interfaces
{
    public interface IBudgetRepository
    {
        Budget Save(Budget budget);
        Budget? GetByCategory(Guid userId, string category, int year, int month);
        IReadOnlyCollection<Budget> GetByUser(Guid userId);
    }
}
