using FinanceTracker.ConsoleClient.Models;
using FinanceTracker.ConsoleClient.Interfaces;
using System.Globalization;

namespace FinanceTracker.ConsoleClient.Services
{
    public sealed class ConsoleInteractor : IConsoleInteractor
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void WriteLine(string message = "")
        {
            Console.WriteLine(message);
        }

        public void WriteSuccess(string message)
        {
            WriteColoredLine(message, ConsoleColor.Green);
        }

        public void WriteError(string message)
        {
            WriteColoredLine(message, ConsoleColor.Red);
        }

        public void Pause()
        {
            Console.WriteLine();
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        public string ReadRequiredText(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.Trim();
                }

                WriteError("A value is required.");
            }
        }

        public PromptResult<string?> ReadOptionalTextOrBack(string prompt)
        {
            Console.Write($"{prompt} (or 0 to go back): ");
            var input = Console.ReadLine();

            if (input == "0")
            {
                return PromptResult<string?>.Back();
            }

            return PromptResult<string?>.Success(string.IsNullOrWhiteSpace(input) ? null : input.Trim());
        }

        public PromptResult<Guid> ReadGuidOrBack(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (or 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<Guid>.Back();
                }

                if (Guid.TryParse(input, out var value))
                {
                    return PromptResult<Guid>.Success(value);
                }

                WriteError("Please enter a valid GUID.");
            }
        }

        public PromptResult<decimal> ReadDecimalOrBack(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (or 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<decimal>.Back();
                }

                if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var value) && value > 0)
                {
                    return PromptResult<decimal>.Success(value);
                }

                WriteError("Please enter a valid amount greater than zero.");
            }
        }

        public PromptResult<DateTime> ReadDateOrBack(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (or 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<DateTime>.Back();
                }

                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                {
                    return PromptResult<DateTime>.Success(date);
                }

                WriteError("Please enter a valid date in yyyy-MM-dd format.");
            }
        }

        public PromptResult<DateTime?> ReadOptionalDateOrBack(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (or 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<DateTime?>.Back();
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    return PromptResult<DateTime?>.Success(null);
                }

                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                {
                    return PromptResult<DateTime?>.Success(date);
                }

                WriteError("Please enter a valid date in yyyy-MM-dd format or leave it blank.");
            }
        }

        public PromptResult<int> ReadYearOrBack()
        {
            while (true)
            {
                Console.Write("Enter year (or 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<int>.Back();
                }

                if (int.TryParse(input, out var year) && year >= 2000 && year <= 3000)
                {
                    return PromptResult<int>.Success(year);
                }

                WriteError("Please enter a year between 2000 and 3000.");
            }
        }

        public PromptResult<int?> ReadOptionalYearOrBack()
        {
            while (true)
            {
                Console.Write("Filter by year (leave blank to skip, 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<int?>.Back();
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    return PromptResult<int?>.Success(null);
                }

                if (int.TryParse(input, out var year) && year >= 2000 && year <= 3000)
                {
                    return PromptResult<int?>.Success(year);
                }

                WriteError("Please enter a year between 2000 and 3000 or leave it blank.");
            }
        }

        public PromptResult<int> ReadMonthOrBack()
        {
            while (true)
            {
                Console.Write("Enter month (1-12, or 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<int>.Back();
                }

                if (int.TryParse(input, out var month) && month >= 1 && month <= 12)
                {
                    return PromptResult<int>.Success(month);
                }

                WriteError("Please enter a month between 1 and 12.");
            }
        }

        public PromptResult<int?> ReadOptionalMonthOrBack()
        {
            while (true)
            {
                Console.Write("Filter by month (1-12, leave blank to skip, 0 to go back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<int?>.Back();
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    return PromptResult<int?>.Success(null);
                }

                if (int.TryParse(input, out var month) && month >= 1 && month <= 12)
                {
                    return PromptResult<int?>.Success(month);
                }

                WriteError("Please enter a month between 1 and 12 or leave it blank.");
            }
        }

        public PromptResult<FinanceTracker.ConsoleClient.Enums.PaymentType> ReadTransactionTypeOrBack()
        {
            while (true)
            {
                Console.Write("Choose type (1 = Income, 2 = Expense, 0 = Back): ");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return PromptResult<FinanceTracker.ConsoleClient.Enums.PaymentType>.Back();
                }

                if (input == "1")
                {
                    return PromptResult<FinanceTracker.ConsoleClient.Enums.PaymentType>.Success(FinanceTracker.ConsoleClient.Enums.PaymentType.Income);
                }

                if (input == "2")
                {
                    return PromptResult<FinanceTracker.ConsoleClient.Enums.PaymentType>.Success(FinanceTracker.ConsoleClient.Enums.PaymentType.Expense);
                }

                WriteError("Please enter 1 for Income, 2 for Expense, or 0 to go back.");
            }
        }

        private static void WriteColoredLine(string message, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = previousColor;
        }
    }
}
