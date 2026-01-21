using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Interfaces
{
    public interface INotificationService
    {
        Task SendOrderConfirmation(Order order);
    }
}
