using System;
using System.Collections.Generic;
using System.Text;
using Banking_System.Models;

namespace Banking_System.Interfaces;

public interface IAccountManager
{
    void CreateAccount(string accountNumber, string accountHolder);
    void CloseAccount(string accountNumber);
    Account GetAccountDetails(string accountNumber);
}
