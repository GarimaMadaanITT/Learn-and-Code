namespace Banking_System.Models;

public class Account
{
    public string AccountNumber { get; }
    public string AccountHolder { get; set; }
    public decimal Balance { get; private set; }

    public Account(string accountNumber, string accountHolder, decimal balance = 0)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient balance");

        Balance -= amount;
    }

    public override string ToString()
    {
        return $"{AccountNumber}|{AccountHolder}|{Balance}";
    }
}
