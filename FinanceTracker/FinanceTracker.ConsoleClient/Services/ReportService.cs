using FinanceTracker.ConsoleClient.Interfaces;

namespace FinanceTracker.ConsoleClient.Services
{
    public sealed class ReportService : IReportService
    {
        private readonly IFinanceTrackerApiClient _apiClient;
        private readonly IConsoleInteractor _console;

        public ReportService(
            IFinanceTrackerApiClient apiClient,
            IConsoleInteractor console)
        {
            _apiClient = apiClient;
            _console = console;
        }

        public async Task ShowMenuAsync()
        {
            var stayInMenu = true;

            while (stayInMenu)
            {
                WriteScreenTitle("Reports");
                _console.WriteLine("1. View monthly summary");
                _console.WriteLine("0. Back");
                _console.WriteLine();

                var option = _console.ReadRequiredText("Choose an option");
                _console.WriteLine();

                try
                {
                    switch (option.Trim())
                    {
                        case "1":
                            await ViewMonthlySummaryAsync();
                            break;
                        case "0":
                            stayInMenu = false;
                            break;
                        default:
                            _console.WriteError("Please choose a valid menu option.");
                            _console.Pause();
                            break;
                    }
                }
                catch (Exception exception)
                {
                    _console.WriteError(exception.Message);
                    _console.Pause();
                }
            }
        }

        private async Task ViewMonthlySummaryAsync()
        {
            var userIdResult = _console.ReadGuidOrBack("Enter user id");
            if (userIdResult.IsBackSelected) return;

            var yearResult = _console.ReadYearOrBack();
            if (yearResult.IsBackSelected) return;

            var monthResult = _console.ReadMonthOrBack();
            if (monthResult.IsBackSelected) return;

            var summary = await _apiClient.GetMonthlySummaryAsync(
                userIdResult.Value,
                yearResult.Value,
                monthResult.Value);

            _console.WriteLine("Monthly summary");
            _console.WriteLine($"Period        : {summary.Month:D2}/{summary.Year}");
            _console.WriteLine($"Total income  : {summary.TotalIncome:C}");
            _console.WriteLine($"Total expense : {summary.TotalExpense:C}");
            _console.WriteLine($"Savings       : {summary.Savings:C}");
            _console.Pause();
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
