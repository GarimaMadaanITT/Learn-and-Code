using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction Add(Transaction transaction);
        Transaction? GetById(Guid transactionId);
        IReadOnlyCollection<Transaction> GetByUser(Guid userId);
        decimal GetExpenseTotal(Guid userId, string category, int year, int month);
        void Delete(Transaction transaction);
    }
}
