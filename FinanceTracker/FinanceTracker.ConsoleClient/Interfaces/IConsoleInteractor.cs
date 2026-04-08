using FinanceTracker.ConsoleClient.Models;

namespace FinanceTracker.ConsoleClient.Interfaces
{
    public interface IConsoleInteractor
    {
        void Clear();
        void WriteLine(string message = "");
        void WriteSuccess(string message);
        void WriteError(string message);
        void Pause();
        string ReadRequiredText(string prompt);
        PromptResult<string?> ReadOptionalTextOrBack(string prompt);
        PromptResult<Guid> ReadGuidOrBack(string prompt);
        PromptResult<decimal> ReadDecimalOrBack(string prompt);
        PromptResult<DateTime> ReadDateOrBack(string prompt);
        PromptResult<DateTime?> ReadOptionalDateOrBack(string prompt);
        PromptResult<int> ReadYearOrBack();
        PromptResult<int?> ReadOptionalYearOrBack();
        PromptResult<int> ReadMonthOrBack();
        PromptResult<int?> ReadOptionalMonthOrBack();
        PromptResult<FinanceTracker.ConsoleClient.Enums.PaymentType> ReadTransactionTypeOrBack();
    }
}
