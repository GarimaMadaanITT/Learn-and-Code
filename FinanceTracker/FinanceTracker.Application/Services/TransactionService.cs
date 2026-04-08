using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enum;
using FinanceTracker.Domain.Exceptions;
using FinanceTracker.Shared.Interfaces;

namespace FinanceTracker.Application.Services
{
    public sealed class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBudgetRepository _budgetRepository;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IBudgetRepository budgetRepository,
            IUserService userService,
            INotificationService notificationService)
        {
            _transactionRepository = transactionRepository;
            _budgetRepository = budgetRepository;
            _userService = userService;
            _notificationService = notificationService;
        }

        public TransactionDetailsDto AddTransaction(CreateTransactionDto request)
        {
            _userService.EnsureUserExists(request.UserId);

            var transaction = new Transaction(
                request.UserId,
                request.Amount,
                request.Type,
                request.Category,
                request.Date);

            var savedTransaction = _transactionRepository.Add(transaction);
            NotifyIfBudgetExceeded(savedTransaction);

            return MapToDetails(savedTransaction);
        }

        public IReadOnlyCollection<TransactionDetailsDto> GetTransactions(TransactionFilterDto filter)
        {
            _userService.EnsureUserExists(filter.UserId);

            return _transactionRepository.GetByUser(filter.UserId)
                .Where(transaction => MatchesDate(transaction, filter.Date))
                .Where(transaction => MatchesCategory(transaction, filter.Category))
                .Select(MapToDetails)
                .ToList();
        }

        public void DeleteTransaction(Guid transactionId)
        {
            var transaction = _transactionRepository.GetById(transactionId)
                ?? throw new ResourceNotFoundException("Transaction was not found.");

            _transactionRepository.Delete(transaction);
        }

        private void NotifyIfBudgetExceeded(Transaction transaction)
        {
            if (transaction.Type != TransactionType.Expense)
            {
                return;
            }

            var budget = _budgetRepository.GetByCategory(
                transaction.UserId,
                transaction.Category,
                transaction.Date.Year,
                transaction.Date.Month);

            if (budget is null)
            {
                return;
            }

            var spentAmount = _transactionRepository.GetExpenseTotal(
                transaction.UserId,
                transaction.Category,
                transaction.Date.Year,
                transaction.Date.Month);

            if (spentAmount <= budget.Limit)
            {
                return;
            }

            _notificationService.NotifyBudgetExceeded(new BudgetExceededNotificationDto
            {
                UserId = transaction.UserId,
                Category = transaction.Category,
                Year = transaction.Date.Year,
                Month = transaction.Date.Month,
                Limit = budget.Limit,
                Spent = spentAmount
            });
        }

        private static bool MatchesDate(Transaction transaction, DateTime? date)
        {
            return !date.HasValue || transaction.Date.Date == date.Value.Date;
        }

        private static bool MatchesCategory(Transaction transaction, string? category)
        {
            return string.IsNullOrWhiteSpace(category) ||
                   transaction.Category.Equals(category.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        private static TransactionDetailsDto MapToDetails(Transaction transaction)
        {
            return new TransactionDetailsDto
            {
                Id = transaction.Id,
                UserId = transaction.UserId,
                Amount = transaction.Amount,
                Category = transaction.Category,
                Type = transaction.Type,
                Date = transaction.Date
            };
        }
    }
}
