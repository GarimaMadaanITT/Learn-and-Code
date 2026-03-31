using FinanceTracker.Domain.Dtos;

namespace FinanceTracker.Application.Interfaces
{
    public interface IUserService
    {
        UserDetailsDto CreateUser(CreateUserDto request);
        UserDetailsDto GetUser(Guid userId);
        void EnsureUserExists(Guid userId);
    }
}
