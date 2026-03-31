using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Services
{
    public sealed class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserService _userService;

        public BudgetService(
            IBudgetRepository budgetRepository,
            ITransactionRepository transactionRepository,
            IUserService userService)
        {
            _budgetRepository = budgetRepository;
            _transactionRepository = transactionRepository;
            _userService = userService;
        }

        public BudgetDetailsDto SetBudget(CreateBudgetDto request)
        {
            _userService.EnsureUserExists(request.UserId);

            var budget = new Budget(
                request.UserId,
                request.Category,
                request.Limit,
                request.Year,
                request.Month);

            var savedBudget = _budgetRepository.Save(budget);
            return MapToDetails(savedBudget);
        }

        public IReadOnlyCollection<BudgetDetailsDto> GetBudgets(BudgetFilterDto filter)
        {
            _userService.EnsureUserExists(filter.UserId);

            return _budgetRepository.GetByUser(filter.UserId)
                .Where(budget => MatchesPeriod(budget, filter.Year, filter.Month))
                .Select(MapToDetails)
                .ToList();
        }

        private static bool MatchesPeriod(Budget budget, int? year, int? month)
        {
            return (!year.HasValue || budget.Year == year.Value) &&
                   (!month.HasValue || budget.Month == month.Value);
        }

        private BudgetDetailsDto MapToDetails(Budget budget)
        {
            var spentAmount = _transactionRepository.GetExpenseTotal(
                budget.UserId,
                budget.Category,
                budget.Year,
                budget.Month);

            return new BudgetDetailsDto
            {
                Id = budget.Id,
                UserId = budget.UserId,
                Category = budget.Category,
                Limit = budget.Limit,
                Year = budget.Year,
                Month = budget.Month,
                Spent = spentAmount,
                IsExceeded = spentAmount > budget.Limit
            };
        }
    }
}
