using FinanceTracker.ConsoleClient.Models;
using FinanceTracker.ConsoleClient.Interfaces;

namespace FinanceTracker.ConsoleClient.Services
{
    public sealed class TransactionService : ITransactionService
    {
        private readonly IFinanceTrackerApiClient _apiClient;
        private readonly IConsoleInteractor _console;

        public TransactionService(
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
                WriteScreenTitle("Transactions");
                _console.WriteLine("1. Add transaction");
                _console.WriteLine("2. View transactions");
                _console.WriteLine("3. Delete transaction");
                _console.WriteLine("0. Back");
                _console.WriteLine();

                var option = _console.ReadRequiredText("Choose an option");
                _console.WriteLine();

                try
                {
                    switch (option.Trim())
                    {
                        case "1":
                            await AddTransactionAsync();
                            break;
                        case "2":
                            await ViewTransactionsAsync();
                            break;
                        case "3":
                            await DeleteTransactionAsync();
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

        private async Task AddTransactionAsync()
        {
            var userIdResult = _console.ReadGuidOrBack("Enter user id");
            if (userIdResult.IsBackSelected) return;

            var typeResult = _console.ReadTransactionTypeOrBack();
            if (typeResult.IsBackSelected) return;

            var amountResult = _console.ReadDecimalOrBack("Enter amount");
            if (amountResult.IsBackSelected) return;

            var category = _console.ReadRequiredText("Enter category");

            var dateResult = _console.ReadDateOrBack("Enter transaction date (yyyy-MM-dd)");
            if (dateResult.IsBackSelected) return;

            var transaction = await _apiClient.CreateTransactionAsync(new CreateTransactionRequest
            {
                UserId = userIdResult.Value,
                Type = typeResult.Value,
                Amount = amountResult.Value,
                Category = category,
                Date = dateResult.Value
            });

            _console.WriteSuccess($"Transaction created with id {transaction.Id}");
            _console.Pause();
        }

        private async Task ViewTransactionsAsync()
        {
            var userIdResult = _console.ReadGuidOrBack("Enter user id");
            if (userIdResult.IsBackSelected) return;

            var dateResult = _console.ReadOptionalDateOrBack("Filter by date (yyyy-MM-dd, leave blank to skip)");
            if (dateResult.IsBackSelected) return;

            var categoryResult = _console.ReadOptionalTextOrBack("Filter by category (leave blank to skip)");
            if (categoryResult.IsBackSelected) return;

            var transactions = await _apiClient.GetTransactionsAsync(
                userIdResult.Value,
                dateResult.Value,
                categoryResult.Value);

            if (transactions.Count == 0)
            {
                _console.WriteLine("No transactions found.");
                _console.Pause();
                return;
            }

            _console.WriteLine("Transactions");

            foreach (var transaction in transactions)
            {
                _console.WriteLine($"{transaction.Id} | {transaction.Date:yyyy-MM-dd} | {transaction.Type} | {transaction.Category} | {transaction.Amount:C}");
            }

            _console.Pause();
        }

        private async Task DeleteTransactionAsync()
        {
            var transactionIdResult = _console.ReadGuidOrBack("Enter transaction id to delete");
            if (transactionIdResult.IsBackSelected) return;

            await _apiClient.DeleteTransactionAsync(transactionIdResult.Value);
            _console.WriteSuccess("Transaction deleted.");
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
