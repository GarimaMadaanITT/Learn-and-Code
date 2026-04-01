using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;

namespace Payment.Processing;

public class PaymentProcessor
{
    private static readonly decimal _minAmount = 0.01m;

    private const int MAX_RETRIES = 2;
    private const string PAYMENT_SUCCESS = "Payment successful";
    private const string PAYMENT_FAILED = "Payment failed";

    private Logger logger;
    private NotificationService notifier;

    private Mapp<string, PaymentRecord> history;

    public PaymentProcessor(Logger logger, NotificationService notifier)
    {
        this.logger = logger;
        this.notifier = notifier;
        this.history = new Dictionary<string, PaymentRecord>();
    }

    public PaymentResult Process(PaymentRequest request)
    {
        Validate(request);
        int attempt = 0;
        while (attempt < MAX_RETRIES)
        {
            try
            {
                Execute(request);
                Record(request);
                NotifySuccess(request);
                return new PaymentResult(true,PAYMENT_SUCCESS,generateId());
            }
            catch(PaymentException e)
            {
                attempt++; 
                logger.Log("Retry attempt: "+attempt); 
            }
        }
        return new PaymentResult(false,PAYMENT_FAILED,null);
    }

    private void Validate(PaymentRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.customerId()))
        {
            throw new IllegalArgumentException("Customer ID required");

        }

        if(request.Amount < _minAmount)
        {
            throw new IllegalArgumentException("Invalid amount");
        }
    }

    private void Execute(PaymentRequest request)
    {
        logger.Log("Executing payment of " + request.Amount()); 

        if(request.Amount() > 5000m)
        {
            throw new PaymentException("Limit exceeded");
        }
    }

    private void Record(PaymentRequest request)
    {
       history[GenerateId()] = new PaymentRecord(
                request.CustomerId,
                request.Amount,
                DateTime.Now
            );
    }

    private void NotifySuccess(PaymentRequest request)
    {
        notifier.Send(request.CustomerId(), $"Payment of {request.Amount} processed");
    }

    private String GenerateId()
    { 
        return "TXN-" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    } 
}   