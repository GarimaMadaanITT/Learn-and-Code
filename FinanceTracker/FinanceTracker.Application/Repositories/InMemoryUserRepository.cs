using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Repositories
{
    public sealed class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public User Add(User user)
        {
            _users.Add(user);
            return user;
        }

        public User? GetById(Guid userId)
        {
            return _users.FirstOrDefault(user => user.Id == userId);
        }
    }
}
