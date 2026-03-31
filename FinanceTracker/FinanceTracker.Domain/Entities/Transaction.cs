using FinanceTracker.Domain.Enum;
using FinanceTracker.Domain.Exceptions;

namespace FinanceTracker.Domain.Entities
{
    public sealed class Transaction
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public decimal Amount { get; }
        public TransactionType Type { get; }
        public string Category { get; }
        public DateTime Date { get; }

        public Transaction(Guid userId, decimal amount, TransactionType type, string? category, DateTime date)
        {
            if (userId == Guid.Empty)
            {
                throw new DomainValidationException("UserId is required.");
            }

            if (amount <= 0)
            {
                throw new DomainValidationException("Amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new DomainValidationException("Category is required.");
            }

            if (date == default)
            {
                throw new DomainValidationException("Transaction date is required.");
            }

            Id = Guid.NewGuid();
            UserId = userId;
            Amount = amount;
            Type = type;
            Category = category.Trim();
            Date = date;
        }
    }
}
