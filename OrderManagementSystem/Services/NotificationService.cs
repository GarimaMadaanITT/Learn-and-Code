using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Services;

public class NotificationService : INotificationService
{
    public Task SendOrderConfirmation(Order order)
    {
        Console.WriteLine("Order confirmation sent.");
        return Task.CompletedTask;
    }
}
