using FinanceTracker.ConsoleClient.Infrastructure;
using FinanceTracker.ConsoleClient.Interfaces;
using FinanceTracker.ConsoleClient.Services;
using FinanceTracker.ConsoleClient.Presentation;
using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-IN");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-IN");

var settingsPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
var apiSettings = SettingsLoader.Load(settingsPath);

using var httpClient = new HttpClient
{
    BaseAddress = new Uri(apiSettings.BaseUrl, UriKind.Absolute)
};

IConsoleInteractor console = new ConsoleInteractor();
IFinanceTrackerApiClient apiClient = new FinanceTrackerApiClient(httpClient);
IAuthenticationService authenticationService = new AuthenticationService(apiClient, console);
ITransactionService transactionService = new TransactionService(apiClient, console);
IBudgetService budgetService = new BudgetService(apiClient, console);
IReportService reportService = new ReportService(apiClient, console);

var application = new FinanceTrackerConsoleApp(
    console,
    authenticationService,
    transactionService,
    budgetService,
    reportService);

await application.RunAsync();
