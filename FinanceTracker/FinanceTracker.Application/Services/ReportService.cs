using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;

namespace FinanceTracker.Application.Services
{
    public sealed class ReportService : IReportService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserService _userService;

        public ReportService(ITransactionRepository transactionRepository, IUserService userService)
        {
            _transactionRepository = transactionRepository;
            _userService = userService;
        }

        public MonthlySummaryDto GetSummary(MonthlySummaryQueryDto query)
        {
            _userService.EnsureUserExists(query.UserId);

            var monthlyTransactions = _transactionRepository.GetByUser(query.UserId)
                .Where(transaction => transaction.Date.Year == query.Year)
                .Where(transaction => transaction.Date.Month == query.Month)
                .ToList();

            var totalIncome = monthlyTransactions
                .Where(transaction => transaction.Type == Domain.Enum.TransactionType.Income)
                .Sum(transaction => transaction.Amount);

            var totalExpense = monthlyTransactions
                .Where(transaction => transaction.Type == Domain.Enum.TransactionType.Expense)
                .Sum(transaction => transaction.Amount);

            return new MonthlySummaryDto
            {
                Year = query.Year,
                Month = query.Month,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Savings = totalIncome - totalExpense
            };
        }
    }
}
