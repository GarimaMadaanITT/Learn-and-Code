using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Services;

public class InventoryService : IInventoryService
{
    public Task<bool> CheckAvailability(List<OrderItem> items)
        => Task.FromResult(true);

    public Task ReserveItems(List<OrderItem> items)
        => Task.CompletedTask;

    public Task CommitReservation(List<OrderItem> items)
        => Task.CompletedTask;

    public Task ReleaseReservation(List<OrderItem> items)
        => Task.CompletedTask;

    public Task RestoreInventory(List<OrderItem> items)
        => Task.CompletedTask;
}