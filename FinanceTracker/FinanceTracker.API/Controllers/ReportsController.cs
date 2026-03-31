using FinanceTracker.API.Extensions;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("reports")]
    public sealed class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("summary")]
        public ActionResult<MonthlySummaryDto> GetMonthlySummary([FromQuery] MonthlySummaryQueryDto query)
        {
            try
            {
                var summary = _reportService.GetSummary(query);
                return Ok(summary);
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }
    }
}
