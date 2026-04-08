using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        User? GetById(Guid userId);
    }
}
