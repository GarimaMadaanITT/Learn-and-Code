using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Models;
using OrderManagementSystem.Results;

namespace OrderManagementSystem.Services;

public class PaymentGateway : IPaymentGateway
{
    public Task<PaymentResult> ProcessPayment(string customerId, decimal amount, PaymentMethod paymentMethod)
    {
        var transactionId = GenerateTransactionId();
        return Task.FromResult(PaymentResult.Success(transactionId));
    }

    public Task RefundPayment(string transactionId)
    {
        LogRefund(transactionId);
        return Task.CompletedTask;
    }

    #region Region Helpers

    private static string GenerateTransactionId()
    {
        return Guid.NewGuid().ToString("N");
    }

    private static void LogRefund(string transactionId)
    {
        Console.WriteLine($"Refund processed for transaction {transactionId}");
    }

    #endregion
}
