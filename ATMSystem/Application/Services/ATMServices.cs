using ATMSystem.Domain.Entities;
using ATMSystem.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSystem.Application.Services;

public class ATMService
{
    public void Withdraw(string accountId, double amount)
    {
        var handle = GetHandle("DEV1");
        ValidateHandle(handle);

        var record = RetrieveDeviceRecord(handle);
        ValidateDevice(record);

        ValidateNetwork(record);
        ValidateBalance(accountId, amount);

        // 🎯 Happy Path (Clean & Readable)
        DispenseCash(handle, amount);
    }

    private void ValidateHandle(DeviceHandle handle)
    {
        if (handle == null || !handle.IsValid)
            throw new DeviceNotFoundException();
    }

    private void ValidateDevice(DeviceRecord record)
    {
        if (record.IsSuspended)
            throw new DeviceLockedException();
    }

    private void ValidateNetwork(DeviceRecord record)
    {
        if (!record.IsConnectedToWifi)
            throw new NetworkConnectionException();
    }

    private void ValidateBalance(string accountId, double amount)
    {
        if (GetBalance(accountId) < amount)
            throw new InsufficientFundsException();
    }

    private DeviceHandle GetHandle(string deviceId)
    {
        return new DeviceHandle { IsValid = true };
    }

    private DeviceRecord RetrieveDeviceRecord(DeviceHandle handle)
    {
        return new DeviceRecord
        {
            IsSuspended = false,
            IsConnectedToWifi = true
        };
    }

    private double GetBalance(string accountId)
    {
        return 1000;
    }

    private void DispenseCash(DeviceHandle handle, double amount)
    {
        Console.WriteLine($"Dispensed {amount}");
    }
}
