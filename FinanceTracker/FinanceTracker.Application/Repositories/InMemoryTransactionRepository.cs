using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enum;

namespace FinanceTracker.Application.Repositories
{
    public sealed class InMemoryTransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new();

        public Transaction Add(Transaction transaction)
        {
            _transactions.Add(transaction);
            return transaction;
        }

        public Transaction? GetById(Guid transactionId)
        {
            return _transactions.FirstOrDefault(transaction => transaction.Id == transactionId);
        }

        public IReadOnlyCollection<Transaction> GetByUser(Guid userId)
        {
            return _transactions
                .Where(transaction => transaction.UserId == userId)
                .OrderByDescending(transaction => transaction.Date)
                .ToList();
        }

        public decimal GetExpenseTotal(Guid userId, string category, int year, int month)
        {
            return _transactions
                .Where(transaction => transaction.UserId == userId)
                .Where(transaction => transaction.Type == TransactionType.Expense)
                .Where(transaction => transaction.Date.Year == year && transaction.Date.Month == month)
                .Where(transaction => transaction.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .Sum(transaction => transaction.Amount);
        }

        public void Delete(Transaction transaction)
        {
            _transactions.Remove(transaction);
        }
    }
}
