using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSystem.Domain.Entities;

public class DeviceRecord
{
    public bool IsSuspended { get; set; }
    public bool IsConnectedToWifi { get; set; }
}
