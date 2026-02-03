using OrderManagementSystem.Application;
using OrderManagementSystem.Models;
using OrderManagementSystem.Results;
using OrderManagementSystem.Services;

class Program
{
    static async Task Main()
    {
        PaymentGateway paymentGateway = new PaymentGateway();
        InventoryService inventoryService = new InventoryService();
        NotificationService notificationService = new NotificationService();

        OrderProcessor orderProcessor = new OrderProcessor(paymentGateway, inventoryService, notificationService);

        Order order = new Order
        {
            CustomerId = "CUST-101",
            TotalAmount = 2500,
            PaymentMethod = PaymentMethod.Card,
            Items = new List<OrderItem>
            {
                new OrderItem { ProductId = "P1", Quantity = 2 }
            },
        };

        OrderResult result = await orderProcessor.ProcessOrder(order);

        Console.WriteLine(result.Message);
    }
}
