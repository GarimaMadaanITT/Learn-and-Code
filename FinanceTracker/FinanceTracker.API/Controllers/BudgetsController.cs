using FinanceTracker.API.Extensions;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("budgets")]
    public sealed class BudgetsController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetsController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpPost]
        public ActionResult<BudgetDetailsDto> SetBudget([FromBody] CreateBudgetDto request)
        {
            try
            {
                var budget = _budgetService.SetBudget(request);
                return Ok(budget);
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<BudgetDetailsDto>> GetBudgets([FromQuery] BudgetFilterDto filter)
        {
            try
            {
                var budgets = _budgetService.GetBudgets(filter);
                return Ok(budgets);
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }
    }
}
