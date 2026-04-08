namespace FinanceTracker.ConsoleClient.Interfaces
{
    public interface IAuthenticationService
    {
        Task SignUpAsync();
        Task LoginAsync();
    }
}
