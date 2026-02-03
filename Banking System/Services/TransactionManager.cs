using Banking_System.Config;
using Banking_System.Interfaces;
using Banking_System.Models;

public class TransactionManager : ITransactionManager
{
    private readonly IAccountManager _accountManager;

    public TransactionManager(IAccountManager accountManager)
    {
        _accountManager = accountManager;
        Directory.CreateDirectory("Data");
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        Account account = _accountManager.GetAccountDetails(accountNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return;
        }

        account.Deposit(amount);

        SaveTransaction(new Transaction(accountNumber, "Deposit", amount));
        Console.WriteLine("Deposit successful.");
    }

    public void Withdraw(string accountNumber, decimal amount)
    {
        Account account = _accountManager.GetAccountDetails(accountNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return;
        }

        account.Withdraw(amount);

        SaveTransaction(new Transaction(accountNumber, "Withdraw", amount));
        Console.WriteLine("Withdrawal successful.");
    }

    private void SaveTransaction(Transaction transaction)
    {
        File.AppendAllText(AppConfig.TransactionFilePath,transaction + Environment.NewLine);
    }
}
