namespace PaymentSystem.Customer
{
    using PaymentSystem.Wallet;
    using PaymentSystem.Payment;

    public class Customer
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly Wallet _wallet;

        public Customer(string firstName, string lastName, Wallet wallet)
        {
            _firstName = firstName;
            _lastName = lastName;
            _wallet = wallet;
        }

        public PaymentResult Pay(double amount)
        {
            if (_wallet.HasEnough(amount))
            {
                _wallet.Debit(amount);
                return PaymentResult.Success();
            }

            return PaymentResult.Failure("Insufficient funds");
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }
    }
}