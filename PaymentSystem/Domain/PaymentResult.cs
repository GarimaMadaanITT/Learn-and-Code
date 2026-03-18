namespace PaymentSystem.Payment
{
    public class PaymentResult
    {
        public bool IsSuccessful { get; }
        public string Message { get; }

        private PaymentResult(bool success, string message)
        {
            IsSuccessful = success;
            Message = message;
        }

        public static PaymentResult Success()
        {
            return new PaymentResult(true, "Payment successful");
        }

        public static PaymentResult Failure(string message)
        {
            return new PaymentResult(false, message);
        }
    }
}