using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Exceptions;

namespace FinanceTracker.Application.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDetailsDto CreateUser(CreateUserDto request)
        {
            var user = new User(request.Name);
            var savedUser = _userRepository.Add(user);
            return MapToDetails(savedUser);
        }

        public UserDetailsDto GetUser(Guid userId)
        {
            return MapToDetails(GetExistingUser(userId));
        }

        public void EnsureUserExists(Guid userId)
        {
            GetExistingUser(userId);
        }

        private User GetExistingUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new DomainValidationException("UserId is required.");
            }

            return _userRepository.GetById(userId)
                ?? throw new ResourceNotFoundException("User was not found.");
        }

        private static UserDetailsDto MapToDetails(User user)
        {
            return new UserDetailsDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }
    }
}
