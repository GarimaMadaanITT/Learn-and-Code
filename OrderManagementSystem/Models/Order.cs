namespace OrderManagementSystem.Models;

public class Order
{
    public string CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public OrderStatus Status { get; private set; }
    public string TransactionId { get; private set; }

    public bool IsValid()
    {
        return Items.Any() && TotalAmount > 0;
    }

    public bool CanBeCancelled()
    {
        return Status == OrderStatus.Paid;
    }

    public void MarkPaid(string transactionId)
    {
        Status = OrderStatus.Paid;
        TransactionId = transactionId;
    }

    public void MarkCancelled()
    {
        Status = OrderStatus.Cancelled;
    }
}