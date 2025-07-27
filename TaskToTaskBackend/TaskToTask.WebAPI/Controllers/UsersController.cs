using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.MediatR.Users.Commands;
using TaskToTask.Application.MediatR.Users.Queries;
using TaskToTask.Application.Models.Requests.Users;
using TaskToTask.Application.Models.Responses.Users;

namespace TaskToTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpGet("id={userId:guid}")]
        public async Task<ActionResult<UserResponse>> GetUserById(Guid userId, CancellationToken ct)
        {
            var user = await mediator.Send(new GetUserByIdQuery(userId), ct);

            var userResponse = new UserResponse(
                UserId: user.Id.ToString(),
                Username: user.Username,
                Email: user.Email,
                Role: user.Role.ToString(),
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt);

            return Ok(userResponse);
        }

        [HttpGet("username={username}")]
        public async Task<ActionResult<UserResponse>> GetUserByUsername(string username, CancellationToken ct)
        {
            var user = await mediator.Send(new GetUserByUsernameQuery(username), ct);

            var userResponse = new UserResponse(
                UserId: user.Id.ToString(),
                Username: user.Username,
                Email: user.Email,
                Role: user.Role.ToString(),
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt);

            return Ok(userResponse);
        }

        [HttpGet("email={email}")]
        public async Task<ActionResult<UserResponse>> GetUserByEmail(string email, CancellationToken ct)
        {
            var user = await mediator.Send(new GetUserByEmailQuery(email), ct);

            var userResponse = new UserResponse(
                UserId: user.Id.ToString(),
                Username: user.Username,
                Email: user.Email,
                Role: user.Role.ToString(),
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt);

            return Ok(userResponse);
        }
        
        [HttpPut("{userId}/email")]
        [Authorize]
        public async Task<IActionResult> ChangeEmail(
            [FromRoute] Guid userId, 
            [FromBody] ChangeEmailRequest request, 
            CancellationToken ct)
        {
            var resultMessage = await mediator.Send(
                new ChangeEmailCommand(userId, request.NewEmail), 
                ct);

            return Ok(new
            {
                Message = resultMessage,
                UserId = userId,
                NewEmail = request.NewEmail
            });
        }
        
        [HttpPut("{userId}/password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(
            [FromRoute] Guid userId, 
            [FromBody] ChangePasswordRequest request, 
            CancellationToken ct)
        {
            var resultMessage = await mediator.Send(
                new ChangePasswordCommand(userId, request.NewPassword, request.ConfirmNewPassword), 
                ct);

            return Ok(new
            {
                Message = resultMessage,
                UserId = userId
            });
        }
    }
}