using FinanceTracker.Domain.Dtos;
using FinanceTracker.Shared.Interfaces;

namespace FinanceTracker.Shared.Adapters
{
    public sealed class ConsoleNotificationAdapter : INotificationService
    {
        public void NotifyBudgetExceeded(BudgetExceededNotificationDto notification)
        {
            Console.WriteLine($"[ALERT] Budget exceeded for user {notification.UserId} in {notification.Category} ({notification.Month:D2}/{notification.Year}). Limit: {notification.Limit}, Spent: {notification.Spent}.");
        }
    }
}
