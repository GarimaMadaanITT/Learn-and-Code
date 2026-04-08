using FinanceTracker.ConsoleClient.Enums;

namespace FinanceTracker.ConsoleClient.Models
{
    public sealed class CreateTransactionRequest
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public PaymentType Type { get; set; }
        public DateTime Date { get; set; }
    }
}
