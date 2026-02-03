using Banking_System.Interfaces;
using Banking_System.Services;
using Banking_System.Repository;
using Banking_System.Menu;

class Program
{
    static void Main(string[] args)
    {
        IAccountRepository repository = new AccountRepository();
        AccountService accountService = new AccountService(repository);
        TransactionService transactionService = new TransactionService(repository);
        LoanService loanService = new LoanService(repository);

        UserInterface ui = new UserInterface(accountService, transactionService, loanService);
        ui.Run();
    }
}
