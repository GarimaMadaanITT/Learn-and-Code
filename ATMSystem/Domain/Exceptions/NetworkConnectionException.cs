using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSystem.Domain.Exceptions;

public class NetworkConnectionException : Exception
{
    public NetworkConnectionException() : base("Network connection error.") { }
}
