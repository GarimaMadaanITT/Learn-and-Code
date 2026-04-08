using FinanceTracker.ConsoleClient.Models;
using FinanceTracker.ConsoleClient.Interfaces;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace FinanceTracker.ConsoleClient.Infrastructure
{
    public sealed class FinanceTrackerApiClient : IFinanceTrackerApiClient
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly HttpClient _httpClient;

        public FinanceTrackerApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailsResponse> CreateUserAsync(CreateUserRequest request)
        {
            return await SendAsync<UserDetailsResponse>(() => _httpClient.PostAsJsonAsync("users", request));
        }

        public async Task<UserDetailsResponse> GetUserAsync(Guid userId)
        {
            return await SendAsync<UserDetailsResponse>(() => _httpClient.GetAsync($"users/{userId}"));
        }

        public async Task<TransactionDetailsResponse> CreateTransactionAsync(CreateTransactionRequest request)
        {
            return await SendAsync<TransactionDetailsResponse>(() => _httpClient.PostAsJsonAsync("transactions", request));
        }

        public async Task<IReadOnlyCollection<TransactionDetailsResponse>> GetTransactionsAsync(Guid userId, DateTime? date, string? category)
        {
            var queryParameters = new List<string> { $"userId={Uri.EscapeDataString(userId.ToString())}" };

            if (date.HasValue)
            {
                queryParameters.Add($"date={Uri.EscapeDataString(date.Value.ToString("O"))}");
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                queryParameters.Add($"category={Uri.EscapeDataString(category.Trim())}");
            }

            var url = $"transactions?{string.Join("&", queryParameters)}";
            return await SendAsync<List<TransactionDetailsResponse>>(() => _httpClient.GetAsync(url));
        }

        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            await SendWithoutContentAsync(() => _httpClient.DeleteAsync($"transactions/{transactionId}"));
        }

        public async Task<BudgetDetailsResponse> SetBudgetAsync(CreateBudgetRequest request)
        {
            return await SendAsync<BudgetDetailsResponse>(() => _httpClient.PostAsJsonAsync("budgets", request));
        }

        public async Task<IReadOnlyCollection<BudgetDetailsResponse>> GetBudgetsAsync(Guid userId, int? year, int? month)
        {
            var queryParameters = new List<string> { $"userId={Uri.EscapeDataString(userId.ToString())}" };

            if (year.HasValue)
            {
                queryParameters.Add($"year={year.Value}");
            }

            if (month.HasValue)
            {
                queryParameters.Add($"month={month.Value}");
            }

            var url = $"budgets?{string.Join("&", queryParameters)}";
            return await SendAsync<List<BudgetDetailsResponse>>(() => _httpClient.GetAsync(url));
        }

        public async Task<MonthlySummaryResponse> GetMonthlySummaryAsync(Guid userId, int year, int month)
        {
            var url = $"reports/summary?userId={Uri.EscapeDataString(userId.ToString())}&year={year}&month={month}";
            return await SendAsync<MonthlySummaryResponse>(() => _httpClient.GetAsync(url));
        }

        private async Task<TResponse> SendAsync<TResponse>(Func<Task<HttpResponseMessage>> sendRequest)
        {
            using var response = await sendRequest();

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new InvalidOperationException("The API returned no content when a response body was expected.");
            }

            if (!response.IsSuccessStatusCode)
            {
                throw await CreateApiExceptionAsync(response);
            }

            var result = await response.Content.ReadFromJsonAsync<TResponse>(SerializerOptions);

            if (result is null)
            {
                throw new InvalidOperationException("The API response could not be read.");
            }

            return result;
        }

        private async Task SendWithoutContentAsync(Func<Task<HttpResponseMessage>> sendRequest)
        {
            using var response = await sendRequest();

            if (!response.IsSuccessStatusCode)
            {
                throw await CreateApiExceptionAsync(response);
            }
        }

        private static async Task<Exception> CreateApiExceptionAsync(HttpResponseMessage response)
        {
            var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>(SerializerOptions);
            var message = error?.Message;

            if (string.IsNullOrWhiteSpace(message))
            {
                message = $"The API request failed with status code {(int)response.StatusCode}.";
            }

            return new InvalidOperationException(message);
        }
    }
}
