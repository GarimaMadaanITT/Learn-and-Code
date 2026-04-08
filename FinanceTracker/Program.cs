using FinanceTracker.Application.Interfaces;
using FinanceTracker.Application.Repositories;
using FinanceTracker.Application.Services;
using FinanceTracker.Shared.Adapters;
using FinanceTracker.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .ConfigureApplicationPartManager(manager =>
    {
        manager.ApplicationParts.Clear();
        manager.ApplicationParts.Add(new AssemblyPart(Assembly.GetExecutingAssembly()));
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<ITransactionRepository, InMemoryTransactionRepository>();
builder.Services.AddSingleton<IBudgetRepository, InMemoryBudgetRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddSingleton<INotificationService, ConsoleNotificationAdapter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
