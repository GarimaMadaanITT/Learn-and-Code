using FinanceTracker.API.Extensions;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("users")]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserDetailsDto> CreateUser([FromBody] CreateUserDto request)
        {
            try
            {
                var user = _userService.CreateUser(request);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }

        [HttpGet("{id:guid}")]
        public ActionResult<UserDetailsDto> GetUser(Guid id)
        {
            try
            {
                var user = _userService.GetUser(id);
                return Ok(user);
            }
            catch (Exception exception)
            {
                return this.HandleException(exception);
            }
        }
    }
}
