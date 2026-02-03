using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_System.Interfaces;

public interface ITransactionManager
{
    void Deposit(string accountNumber, decimal amount);
    void Withdraw(string accountNumber, decimal amount);
    //void Transfer(string fromAccount, string toAccount, decimal amount);
}
