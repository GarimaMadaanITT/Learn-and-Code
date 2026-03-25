using ATMSystem.Application.Services;
using ATMSystem.Domain.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        var atmService = new ATMService();

        try
        {
            atmService.Withdraw("ACC123", 500);
            Console.WriteLine("Transaction Successful");
        }
        catch (DeviceLockedException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (NetworkConnectionException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}