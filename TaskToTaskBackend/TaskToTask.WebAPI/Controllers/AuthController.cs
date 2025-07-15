using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.Commands.Users.GetMe;
using TaskToTask.Application.Commands.Users.LoginUser;
using TaskToTask.Domain.Models;
using TaskToTask.WebAPI.DTOs.Requests.Users;
using TaskToTask.WebAPI.DTOs.Responses.Users;

namespace TaskToTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest dto, CancellationToken ct)
        {
            var token = await _mediator.Send(
                new LoginUserCommand(
                    dto.UsernameOrEmail,
                    dto.Password), ct);

            Response.Cookies.Append("session_token", token);

            return Ok("Вход выполнен");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("session_token");

            return Ok("Выход выполнен");
        }

        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GetMeUserResponse>> GetMe(CancellationToken ct)
        {
            var user = await _mediator.Send(new GetMeCommand(), ct);

            var userResponse = new GetMeUserResponse
            {
                UserId = user.Id.ToString(),
                Username = user.Username,
                UserEmail = user.Email,
                UserRole = user.Role.ToString()
            };

            return Ok(userResponse);
        }
    }
}
