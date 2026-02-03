namespace Banking_System.Models;

public class Transaction
{
    private static int _counter = 0;

    public string TransactionID { get; }
    public string AccountNumber { get; }
    public string Type { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }

    public Transaction(string accountNumber, string type, decimal amount)
    {
        TransactionID = "TXN" + ++_counter;
        AccountNumber = accountNumber;
        Type = type;
        Amount = amount;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{TransactionID}|{AccountNumber}|{Type}|{Amount}|{Date}";
    }
}
