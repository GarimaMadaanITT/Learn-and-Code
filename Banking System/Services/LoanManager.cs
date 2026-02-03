using Banking_System.Config;
using Banking_System.Interfaces;
using Banking_System.Models;

namespace Banking_System.Services;

public class LoanManager : ILoanManager
{
    private readonly List<Loan> _loans = new();

    public LoanManager()
    {
        LoadLoans();
    }

    public void ApplyForLoan(string accountNumber,decimal principalAmount,decimal interestRate,int periodInYears)
    {
        string loanId = "LN" + Guid.NewGuid().ToString()[..6];

        Loan loan = new Loan(loanId,principalAmount,interestRate,periodInYears);

        _loans.Add(loan);
        SaveLoans();

        Console.WriteLine($"Loan applied successfully. Loan ID: {loanId}");
    }

    public Loan GetLoanDetails(string loanID)
    {
        return _loans.FirstOrDefault(l => l.LoanID == loanID);
    }

    private void SaveLoans()
    {
        try
        {
            Directory.CreateDirectory("Data");

            using (StreamWriter writer = new StreamWriter(AppConfig.LoanFilePath))
            {
                foreach (var loan in _loans)
                {
                    writer.WriteLine(loan.ToString());
                }
            }

            Console.WriteLine("Loans saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving loans: {ex.Message}");
        }
    }

    private void LoadLoans()
    {
        if (File.Exists(AppConfig.LoanFilePath))
        {
            try
            {
                using (StreamReader reader = new StreamReader(AppConfig.LoanFilePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        _loans.Add(new Loan(parts[0],decimal.Parse(parts[1]),decimal.Parse(parts[2]),int.Parse(parts[3])));
                    }
                }

                Console.WriteLine("Inventory loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading inventory: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Inventory file not found.");
        }
    }
}
