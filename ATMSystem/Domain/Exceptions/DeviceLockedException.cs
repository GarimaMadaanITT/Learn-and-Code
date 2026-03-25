using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSystem.Domain.Exceptions;

public class DeviceLockedException : Exception
{
    public DeviceLockedException() : base("ATM device is suspended.") { }
}