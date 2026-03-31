using FinanceTracker.Domain.Dtos;

namespace FinanceTracker.Shared.Interfaces
{
    public interface INotificationService
    {
        void NotifyBudgetExceeded(BudgetExceededNotificationDto notification);
    }
}
