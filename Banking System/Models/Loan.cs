namespace Banking_System.Models;

public class Loan
{
    public string LoanID { get; }
    public decimal PrincipalAmount { get; set; }
    public decimal InterestRate { get; set; }
    public int PeriodInYears { get; set; }

    public Loan(string loanID, decimal principal, decimal rate, int years)
    {
        LoanID = loanID;
        PrincipalAmount = principal;
        InterestRate = rate;
        PeriodInYears = years;
    }

    public override string ToString()
    {
        return $"{LoanID}|{PrincipalAmount}|{InterestRate}|{PeriodInYears}";
    }
}
