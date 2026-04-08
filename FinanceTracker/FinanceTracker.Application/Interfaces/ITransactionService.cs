using FinanceTracker.Domain.Dtos;

namespace FinanceTracker.Application.Interfaces
{
    public interface ITransactionService
    {
        TransactionDetailsDto AddTransaction(CreateTransactionDto request);
        IReadOnlyCollection<TransactionDetailsDto> GetTransactions(TransactionFilterDto filter);
        void DeleteTransaction(Guid transactionId);
    }
}
