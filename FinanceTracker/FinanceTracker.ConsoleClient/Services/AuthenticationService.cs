using FinanceTracker.ConsoleClient.Models;
using FinanceTracker.ConsoleClient.Interfaces;

namespace FinanceTracker.ConsoleClient.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IFinanceTrackerApiClient _apiClient;
        private readonly IConsoleInteractor _console;

        public AuthenticationService(
            IFinanceTrackerApiClient apiClient,
            IConsoleInteractor console)
        {
            _apiClient = apiClient;
            _console = console;
        }

        public async Task SignUpAsync()
        {
            while (true)
            {
                WriteScreenTitle("Sign Up");
                _console.WriteLine("1. Create account");
                _console.WriteLine("0. Back");
                _console.WriteLine();

                var option = _console.ReadRequiredText("Choose an option");
                _console.WriteLine();

                if (option == "0")
                {
                    return;
                }

                if (option != "1")
                {
                    _console.WriteError("Please choose a valid menu option.");
                    _console.Pause();
                    continue;
                }

                try
                {
                    var name = _console.ReadRequiredText("Enter user name");
                    var createdUser = await _apiClient.CreateUserAsync(new CreateUserRequest { Name = name });

                    _console.WriteSuccess($"Sign up successful. Your user id is {createdUser.Id}");
                    _console.WriteLine("Please save this user id. You will need it when using transactions, budgets, and reports.");
                    _console.Pause();
                    return;
                }
                catch (Exception exception)
                {
                    _console.WriteError(exception.Message);
                    _console.Pause();
                }
            }
        }

        public async Task LoginAsync()
        {
            while (true)
            {
                WriteScreenTitle("Login");
                _console.WriteLine("1. Login with user id");
                _console.WriteLine("0. Back");
                _console.WriteLine();

                var option = _console.ReadRequiredText("Choose an option");
                _console.WriteLine();

                if (option == "0")
                {
                    return;
                }

                if (option != "1")
                {
                    _console.WriteError("Please choose a valid menu option.");
                    _console.Pause();
                    continue;
                }

                try
                {
                    var userIdResult = _console.ReadGuidOrBack("Enter user id");

                    if (userIdResult.IsBackSelected)
                    {
                        return;
                    }

                    var user = await _apiClient.GetUserAsync(userIdResult.Value);

                    _console.WriteSuccess($"Login successful. Welcome, {user.Name}.");
                    _console.WriteLine("Use your user id when working with transactions, budgets, and reports.");
                    _console.Pause();
                    return;
                }
                catch (Exception exception)
                {
                    _console.WriteError(exception.Message);
                    _console.Pause();
                }
            }
        }

        private void WriteScreenTitle(string title)
        {
            _console.Clear();
            _console.WriteLine("Personal Finance Tracker");
            _console.WriteLine(new string('=', 24));
            _console.WriteLine();
            _console.WriteLine(title);
        }
    }
}
