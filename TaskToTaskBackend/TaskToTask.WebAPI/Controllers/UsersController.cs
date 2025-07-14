using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.Commands.Users.RegisterUser;
using TaskToTask.WebAPI.DTOs.Requests.Users;

namespace TaskToTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromBody] RegisterUserRequest dto,
            CancellationToken ct)
        {
            var id = await _mediator.Send(
                new RegisterUserCommand(
                    dto.Username, 
                    dto.Email, 
                    dto.Password, 
                    dto.ConfirmPassword), ct);

            return Ok(id);
        }
    }
}
