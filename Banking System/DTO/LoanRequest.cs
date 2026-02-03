using Banking_System.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_System.DTO;

public class LoanRequest
{
    public string LoanId { get; set; }
    public decimal PrincipalAmount { get; set; }
    public int TermInMonths { get; set; }
    public LoanType LoanType { get; set; }
}
