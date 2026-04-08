namespace FinanceTracker.Domain.Dtos
{
    public sealed class UserDetailsDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
