using OrderManagementSystem.Models;
using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Results;

namespace OrderManagementSystem.Application;

public class OrderProcessor
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IInventoryService _inventoryService;
    private readonly INotificationService _notificationService;

    public OrderProcessor(
        IPaymentGateway paymentGateway,
        IInventoryService inventoryService,
        INotificationService notificationService)
    {
        _paymentGateway = paymentGateway;
        _inventoryService = inventoryService;
        _notificationService = notificationService;
    }

    public async Task<OrderResult> ProcessOrder(Order order)
    {
        verifyIsOrderNull(order);

        if (!order.IsValid())
            return OrderResult.Invalid("Order validation failed");

        if (!await _inventoryService.CheckAvailability(order.Items))
            return OrderResult.Failed("Insufficient inventory");

        await _inventoryService.ReserveItems(order.Items);

        try
        {
            return await ProcessPaymentAndFinalize(order);
        }
        catch
        {
            await _inventoryService.ReleaseReservation(order.Items);
            throw;
        }
    }

    public async Task CancelAsync(string orderId)
    {
        var order = await LoadOrder(orderId);

        if (order.CanBeCancelled())
            await RefundPaymentAndRestoreInventory(order);

        order.MarkCancelled();
        await PersistOrder(order);
    }

    #region Region Helpers

    private static void verifyIsOrderNull(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));
    }

    private async Task<OrderResult> ProcessPaymentAndFinalize(Order order)
    {
        var paymentResult = await _paymentGateway.ProcessPayment(order.CustomerId,order.TotalAmount,order.PaymentMethod);

        if (!paymentResult.IsSuccessful)
        {
            await _inventoryService.ReleaseReservation(order.Items);
            return OrderResult.Failed(paymentResult.ErrorMessage);
        }

        order.MarkPaid(paymentResult.TransactionId);

        await _inventoryService.CommitReservation(order.Items);
        await _notificationService.SendOrderConfirmation(order);

        return OrderResult.Success(paymentResult.TransactionId);
    }

    private async Task RefundPaymentAndRestoreInventory(Order order)
    {
        await _paymentGateway.RefundPayment(order.TransactionId);
        await _inventoryService.RestoreInventory(order.Items);
    }

    private async Task<Order> LoadOrder(string orderId)
    {
        return await Task.FromResult(new Order
        {
            CustomerId = "CUST-101",
            Items = new List<OrderItem>
            {
                new OrderItem { ProductId = "P1", Quantity = 2 }
            }
        });
    }

    private async Task PersistOrder(Order order)
    {
        await Task.CompletedTask;
    }

    #endregion
}