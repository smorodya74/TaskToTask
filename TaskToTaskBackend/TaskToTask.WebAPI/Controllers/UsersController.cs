using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.MediatR.Users.Queries;
using TaskToTask.Application.Models.Responses.Users;

namespace TaskToTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("id={userId:guid}")]
        public async Task<ActionResult<UserResponse>> GetUserById(Guid userId, CancellationToken ct)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(userId), ct);

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
            var user = await _mediator.Send(new GetUserByUsernameQuery(username), ct);

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
            var user = await _mediator.Send(new GetUserByEmailQuery(email), ct);

            var userResponse = new UserResponse(
                UserId: user.Id.ToString(),
                Username: user.Username,
                Email: user.Email,
                Role: user.Role.ToString(),
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt);

            return Ok(userResponse);
        }
        
        // TODO: написать методы changeEmail и changePassword
    }
}