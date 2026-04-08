using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Repositories
{
    public sealed class InMemoryBudgetRepository : IBudgetRepository
    {
        private readonly List<Budget> _budgets = new();

        public Budget Save(Budget budget)
        {
            var existingBudget = GetByCategory(budget.UserId, budget.Category, budget.Year, budget.Month);

            if (existingBudget is null)
            {
                _budgets.Add(budget);
                return budget;
            }

            existingBudget.Update(budget.Limit, budget.Year, budget.Month);
            return existingBudget;
        }

        public Budget? GetByCategory(Guid userId, string category, int year, int month)
        {
            return _budgets.FirstOrDefault(budget =>
                budget.UserId == userId &&
                budget.Year == year &&
                budget.Month == month &&
                budget.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        public IReadOnlyCollection<Budget> GetByUser(Guid userId)
        {
            return _budgets
                .Where(budget => budget.UserId == userId)
                .OrderBy(budget => budget.Year)
                .ThenBy(budget => budget.Month)
                .ThenBy(budget => budget.Category)
                .ToList();
        }
    }
}
