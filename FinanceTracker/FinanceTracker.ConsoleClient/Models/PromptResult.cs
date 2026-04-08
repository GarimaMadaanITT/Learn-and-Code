namespace FinanceTracker.ConsoleClient.Models
{
    public readonly record struct PromptResult<T>(bool IsBackSelected, T Value)
    {
        public static PromptResult<T> Back()
        {
            return new PromptResult<T>(true, default!);
        }

        public static PromptResult<T> Success(T value)
        {
            return new PromptResult<T>(false, value);
        }
    }
}
