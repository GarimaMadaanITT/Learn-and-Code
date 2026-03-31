using FinanceTracker.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Extensions
{
    public static class ControllerExceptionExtensions
    {
        public static ActionResult HandleException(this ControllerBase controller, Exception exception)
        {
            var response = new ErrorResponse(exception.Message);

            return exception switch
            {
                DomainValidationException => controller.BadRequest(response),
                ResourceNotFoundException => controller.NotFound(response),
                _ => controller.StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse("An unexpected error occurred."))
            };
        }

        private sealed record ErrorResponse(string Message);
    }
}
