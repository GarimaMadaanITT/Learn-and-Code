using System;
using System.Collections.Generic;
using System.Text;
using Banking_System.Models;

namespace Banking_System.Interfaces;

public interface IAccountRepository
{
    Account GetAccount(string accountNumber);
    void AddAccount(Account account);
    bool AccountExists(string accountNumber);
}