using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Results
{

    public class OrderResult
    {
        public bool IsSuccessful { get; }
        public string Message { get; }

        private OrderResult(bool success, string message)
        {
            IsSuccessful = success;
            Message = message;
        }

        public static OrderResult Success(string transactionId)
            => new(true, $"Order placed successfully. Transaction: {transactionId}");

        public static OrderResult Failed(string reason)
            => new(false, reason);

        public static OrderResult Invalid(string reason)
            => new(false, reason);
    }
}
