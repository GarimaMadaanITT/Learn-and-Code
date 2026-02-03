using Banking_System.Interfaces;
using Banking_System.Models;

namespace Banking_System.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<string, Account> accounts = new Dictionary<string, Account>();

    public Account GetAccount(string accountNumber)
    {
        if (!accounts.ContainsKey(accountNumber))
        {
            throw new KeyNotFoundException("Account Not Found!");
        }
        return accounts[accountNumber];
    }

    public void AddAccount(Account account)
    {
        if (!accounts.ContainsKey(account.AccountNumber))
            accounts[account.AccountNumber] = account;
    }

    public bool AccountExists(string accountNumber)
    {
        return accounts.ContainsKey(accountNumber);
    }
}    