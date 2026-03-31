using FinanceTracker.ConsoleClient.Models;

namespace FinanceTracker.ConsoleClient.Interfaces
{
    public interface IFinanceTrackerApiClient
    {
        Task<UserDetailsResponse> CreateUserAsync(CreateUserRequest request);
        Task<UserDetailsResponse> GetUserAsync(Guid userId);
        Task<TransactionDetailsResponse> CreateTransactionAsync(CreateTransactionRequest request);
        Task<IReadOnlyCollection<TransactionDetailsResponse>> GetTransactionsAsync(Guid userId, DateTime? date, string? category);
        Task DeleteTransactionAsync(Guid transactionId);
        Task<BudgetDetailsResponse> SetBudgetAsync(CreateBudgetRequest request);
        Task<IReadOnlyCollection<BudgetDetailsResponse>> GetBudgetsAsync(Guid userId, int? year, int? month);
        Task<MonthlySummaryResponse> GetMonthlySummaryAsync(Guid userId, int year, int month);
    }
}
