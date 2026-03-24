using PaymentSystem.App;
using PaymentSystem.Customer;
using DelPaymentSystemiveryPaymentSystem.Wallet;

namespace PaymentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var wallet = new Wallet(100.0);
            var customer = new Customer("Garima", "Madaan", wallet);
            var paperboy = new Paperboy();

            Console.WriteLine("---- Attempt 1 ----");
            paperboy.CollectPayment(customer, 50.0);

            Console.WriteLine("---- Attempt 2 ----");
            paperboy.CollectPayment(customer, 70.0);
        }
    }
}