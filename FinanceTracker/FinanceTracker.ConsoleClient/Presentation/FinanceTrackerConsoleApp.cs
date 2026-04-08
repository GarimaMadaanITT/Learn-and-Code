using FinanceTracker.ConsoleClient.Interfaces;

namespace FinanceTracker.ConsoleClient.Presentation
{
    public sealed class FinanceTrackerConsoleApp
    {
        private readonly IConsoleInteractor _console;
        private readonly IAuthenticationService _authenticationService;
        private readonly ITransactionService _transactionService;
        private readonly IBudgetService _budgetService;
        private readonly IReportService _reportService;

        public FinanceTrackerConsoleApp(
            IConsoleInteractor console,
            IAuthenticationService authenticationService,
            ITransactionService transactionService,
            IBudgetService budgetService,
            IReportService reportService)
        {
            _console = console;
            _authenticationService = authenticationService;
            _transactionService = transactionService;
            _budgetService = budgetService;
            _reportService = reportService;
        }

        public async Task RunAsync()
        {
            var isRunning = true;

            while (isRunning)
            {
                ShowMainMenu();
                var selectedOption = _console.ReadRequiredText("Choose an option");
                _console.WriteLine();

                try
                {
                    isRunning = await ExecuteAuthenticationOptionAsync(selectedOption);
                }
                catch (Exception exception)
                {
                    _console.WriteError(exception.Message);
                    _console.Pause();
                }
            }
        }

        private async Task<bool> ExecuteAuthenticationOptionAsync(string option)
        {
            switch (option.Trim())
            {
                case "1":
                    await _authenticationService.SignUpAsync();
                    return true;
                case "2":
                    await _authenticationService.LoginAsync();
                    return true;
                case "3":
                    await _transactionService.ShowMenuAsync();
                    return true;
                case "4":
                    await _budgetService.ShowMenuAsync();
                    return true;
                case "5":
                    await _reportService.ShowMenuAsync();
                    return true;
                case "0":
                    _console.WriteSuccess("Goodbye.");
                    return false;
                default:
                    _console.WriteError("Please choose a valid menu option.");
                    _console.Pause();
                    return true;
            }
        }

        private void ShowMainMenu()
        {
            WriteApplicationHeader();
            _console.WriteLine("1. Sign up");
            _console.WriteLine("2. Login");
            _console.WriteLine("3. Transactions");
            _console.WriteLine("4. Budgets");
            _console.WriteLine("5. Reports");
            _console.WriteLine("0. Exit");
            _console.WriteLine();
        }

        private void WriteApplicationHeader()
        {
            _console.Clear();
            _console.WriteLine("Personal Finance Tracker");
            _console.WriteLine(new string('=', 24));
            _console.WriteLine();
        }
    }
}
