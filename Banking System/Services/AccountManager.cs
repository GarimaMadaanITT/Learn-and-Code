using Banking_System.Config;
using Banking_System.Interfaces;
using Banking_System.Models;

namespace Banking_System.Services;

public class AccountManager : IAccountManager
{
    private readonly List<Account> _accounts = new List<Account>();

    public AccountManager()
    {
        LoadAccounts();
    }

    public void CreateAccount(string accountNumber, string accountHolder)
    {
        _accounts.Add(new Account(accountNumber, accountHolder));
        SaveAccounts();
    }

    public void CloseAccount(string accountNumber)
    {
        Account account = GetAccountDetails(accountNumber);
        if (account == null)
        {
            Console.WriteLine("Account not found");
            return;
        }

        _accounts.Remove(account);
        SaveAccounts();
    }

    public Account GetAccountDetails(string accountNumber)
    {
        return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    }

    private void SaveAccounts()
    {
        try
        {
            Directory.CreateDirectory("Data");

            using (StreamWriter writer = new StreamWriter(AppConfig.AccountFilePath))
            {
                foreach (var account in _accounts)
                {
                    writer.WriteLine(account.ToString());
                }
            }

            Console.WriteLine("Accounts saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving accounts: {ex.Message}");
        }
    }


    private void LoadAccounts()
    {
        if (File.Exists(AppConfig.AccountFilePath))
        {
            try
            {
                using (StreamReader reader = new StreamReader(AppConfig.AccountFilePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        _accounts.Add(new Account(parts[0], parts[1], decimal.Parse(parts[2])));
                    }
                }
                Console.WriteLine("Accounts loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Accounts: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Accounts file not found.");
        }
    }      
}
