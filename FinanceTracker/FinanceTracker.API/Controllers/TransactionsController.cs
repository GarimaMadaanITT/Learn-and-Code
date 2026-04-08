using FinanceTracker.API.Extensions;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("transactions")]
    public sealed class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public ActionResult<TransactionDetailsDto> CreateTransaction([FromBody] CreateTransactionDto request)
        {
            try
            {
                var transaction = _transactionService.AddTransaction(request);
                return CreatedAtAction(nameof(GetTransactions), new { userId = transaction.UserId }, transaction);
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<TransactionDetailsDto>> GetTransactions([FromQuery] TransactionFilterDto filter)
        {
            try
            {
                var transactions = _transactionService.GetTransactions(filter);
                return Ok(transactions);
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteTransaction(Guid id)
        {
            try
            {
                _transactionService.DeleteTransaction(id);
                return NoContent();
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }
    }
}
