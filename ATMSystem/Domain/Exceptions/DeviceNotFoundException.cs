using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSystem.Domain.Exceptions;

public class DeviceNotFoundException : Exception
{
    public DeviceNotFoundException() : base("Device not found.") { }
}
