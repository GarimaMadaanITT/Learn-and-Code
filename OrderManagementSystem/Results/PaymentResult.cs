using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Results;

public class PaymentResult
{
    public bool IsSuccessful { get; }
    public string TransactionId { get; }
    public string ErrorMessage { get; }

    private PaymentResult(bool success, string transactionId, string error)
    {
        IsSuccessful = success;
        TransactionId = transactionId;
        ErrorMessage = error;
    }

    public static PaymentResult Success(string transactionId)
        => new(true, transactionId, string.Empty);

    public static PaymentResult Failed(string error)
        => new(false, string.Empty, error);
}
