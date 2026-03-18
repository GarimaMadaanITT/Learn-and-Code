namespace DeliveryPaymentSystem.App
{
    using PaymentSystem.Customer;
    using PaymentSystem.Payment;

    public class Paperboy
    {
        public void CollectPayment(Customer customer, double amount)
        {
            PaymentResult result = customer.Pay(amount);

            if (result.IsSuccessful)
            {
                Console.WriteLine("Payment collected successfully.");
            }
            else
            {
                Console.WriteLine("Payment failed. Will come back later.");
            }
        }
    }
}