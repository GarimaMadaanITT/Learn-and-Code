using Banking_System.Interfaces;
using Banking_System.Services;
using Banking_System.Models;
using System;

class Program
{
    static void Main()
    {
        IAccountManager accountManager = new AccountManager();
        ITransactionManager transactionManager = new TransactionManager(accountManager);
        ILoanManager loanManager = new LoanManager();

        while (true)
        {
            Console.WriteLine("\n--- Banking System ---");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Apply for Loan");
            Console.WriteLine("5. View Account Details");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Account Number: ");
                        string accountNumber = Console.ReadLine();

                        Console.Write("Account Holder Name: ");
                        string name = Console.ReadLine();

                        accountManager.CreateAccount(accountNumber, name);
                        Console.WriteLine("Account created successfully.");
                        break;

                    case 2:
                        Console.Write("Account Number: ");
                        accountNumber = Console.ReadLine();

                        Console.Write("Amount: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());

                        transactionManager.Deposit(accountNumber, depositAmount);
                        break;

                    case 3:
                        Console.Write("Account Number: ");
                        accountNumber = Console.ReadLine();

                        Console.Write("Amount: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                        transactionManager.Withdraw(accountNumber, withdrawAmount);
                        break;

                    case 4:
                        Console.Write("Account Number: ");
                        accountNumber = Console.ReadLine();

                        Console.Write("Principal Amount: ");
                        decimal principal = decimal.Parse(Console.ReadLine());

                        Console.Write("Interest Rate: ");
                        decimal rate = decimal.Parse(Console.ReadLine());

                        Console.Write("Period (years): ");
                        int period = int.Parse(Console.ReadLine());

                        loanManager.ApplyForLoan(accountNumber,principal,rate,period
                        );
                        break;

                    case 5:
                        Console.Write("Account Number: ");
                        accountNumber = Console.ReadLine();

                        Account account = accountManager.GetAccountDetails(accountNumber);
                        if (account == null)
                        {
                            Console.WriteLine("Account not found.");
                        }
                        else
                        {
                            Console.WriteLine($"Account Holder: {account.AccountHolder}");
                            Console.WriteLine($"Balance: {account.Balance}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Thank you for using Banking System.");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
