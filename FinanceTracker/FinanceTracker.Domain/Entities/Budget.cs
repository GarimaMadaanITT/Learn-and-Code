using FinanceTracker.Domain.Exceptions;

namespace FinanceTracker.Domain.Entities
{
    public sealed class Budget
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Category { get; private set; }
        public decimal Limit { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }

        public Budget(Guid userId, string? category, decimal limit, int year, int month)
        {
            if (userId == Guid.Empty)
            {
                throw new DomainValidationException("UserId is required.");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new DomainValidationException("Category is required.");
            }

            if (limit <= 0)
            {
                throw new DomainValidationException("Budget limit must be greater than zero.");
            }

            if (year < 2000 || year > 3000)
            {
                throw new DomainValidationException("Year must be between 2000 and 3000.");
            }

            if (month < 1 || month > 12)
            {
                throw new DomainValidationException("Month must be between 1 and 12.");
            }

            Id = Guid.NewGuid();
            UserId = userId;
            Category = category.Trim();
            Limit = limit;
            Year = year;
            Month = month;
        }

        public void Update(decimal limit, int year, int month)
        {
            Limit = limit;
            Year = year;
            Month = month;
        }
    }
}
