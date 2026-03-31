using FinanceTracker.Domain.Exceptions;

namespace FinanceTracker.Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; }
        public string Name { get; }

        public User(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainValidationException("User name is required.");
            }

            Id = Guid.NewGuid();
            Name = name.Trim();
        }
    }
}
