using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSystem.Domain.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base("Insufficient funds.") { }
}
