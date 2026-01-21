using OrderManagementSystem.Models;
using OrderManagementSystem.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Interfaces;

public interface IPaymentGateway
{
    Task<PaymentResult> ProcessPayment(
        string customerId,
        decimal amount,
        PaymentMethod paymentMethod);

    Task RefundPayment(string transactionId);
}
