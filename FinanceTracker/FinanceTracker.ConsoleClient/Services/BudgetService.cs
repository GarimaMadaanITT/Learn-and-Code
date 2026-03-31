using FinanceTracker.ConsoleClient.Models;
using FinanceTracker.ConsoleClient.Interfaces;

namespace FinanceTracker.ConsoleClient.Services
{
    public sealed class BudgetService : IBudgetService
    {
        private readonly IFinanceTrackerApiClient _apiClient;
        private readonly IConsoleInteractor _console;

        public BudgetService(
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
                WriteScreenTitle("Budgets");
                _console.WriteLine("1. Set monthly budget");
                _console.WriteLine("2. View budgets");
                _console.WriteLine("0. Back");
                _console.WriteLine();

                var option = _console.ReadRequiredText("Choose an option");
                _console.WriteLine();

                try
                {
                    switch (option.Trim())
                    {
                        case "1":
                            await SetBudgetAsync();
                            break;
                        case "2":
                            await ViewBudgetsAsync();
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

        private async Task SetBudgetAsync()
        {
            var userIdResult = _console.ReadGuidOrBack("Enter user id");
            if (userIdResult.IsBackSelected) return;

            var category = _console.ReadRequiredText("Enter category");

            var limitResult = _console.ReadDecimalOrBack("Enter monthly budget limit");
            if (limitResult.IsBackSelected) return;

            var yearResult = _console.ReadYearOrBack();
            if (yearResult.IsBackSelected) return;

            var monthResult = _console.ReadMonthOrBack();
            if (monthResult.IsBackSelected) return;

            var budget = await _apiClient.SetBudgetAsync(new CreateBudgetRequest
            {
                UserId = userIdResult.Value,
                Category = category,
                Limit = limitResult.Value,
                Year = yearResult.Value,
                Month = monthResult.Value
            });

            _console.WriteSuccess($"Budget saved for {budget.Category} ({budget.Month:D2}/{budget.Year}). Limit: {budget.Limit:C}, Spent: {budget.Spent:C}");
            _console.Pause();
        }

        private async Task ViewBudgetsAsync()
        {
            var userIdResult = _console.ReadGuidOrBack("Enter user id");
            if (userIdResult.IsBackSelected) return;

            var yearResult = _console.ReadOptionalYearOrBack();
            if (yearResult.IsBackSelected) return;

            var monthResult = _console.ReadOptionalMonthOrBack();
            if (monthResult.IsBackSelected) return;

            var budgets = await _apiClient.GetBudgetsAsync(
                userIdResult.Value,
                yearResult.Value,
                monthResult.Value);

            if (budgets.Count == 0)
            {
                _console.WriteLine("No budgets found.");
                _console.Pause();
                return;
            }

            _console.WriteLine("Budgets");

            foreach (var budget in budgets)
            {
                var status = budget.IsExceeded ? "Exceeded" : "Within limit";
                _console.WriteLine($"{budget.Category} | {budget.Month:D2}/{budget.Year} | Limit: {budget.Limit:C} | Spent: {budget.Spent:C} | {status}");
            }

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
