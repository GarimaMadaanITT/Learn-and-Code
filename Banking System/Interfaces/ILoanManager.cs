using Banking_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_System.Interfaces;

public interface ILoanManager
{
    void ApplyForLoan(string accountNumber, decimal principalAmount, decimal interestRate, int periodInYears);
    Loan GetLoanDetails(string loanID);
}
