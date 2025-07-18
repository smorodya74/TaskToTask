using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.MediatR.Users.Commands;
using TaskToTask.Application.MediatR.Users.Queries;
using TaskToTask.Application.Models;
using TaskToTask.Domain.Models;
using TaskToTask.WebAPI.DTO.Requests.Users;

namespace TaskToTask.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        [HttpPut("{userId}/role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(
            [FromRoute] Guid userId, 
            [FromBody] ChangeRoleRequest request, 
            CancellationToken ct)
        {
            var resultMessage = await _mediator.Send(
                new ChangeRoleCommand(userId, request.Role), 
                ct);

            return Ok(new
            {
                Message = resultMessage,
                UserId = userId,
                UserRole = request.Role
            });
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId, CancellationToken ct)
        {
            var resultMeggase =  await _mediator.Send(new DeleteUserCommand(userId), ct);
            
            return Ok(resultMeggase);
        }
        
        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UsersPageRepsonse<User>>> GetUsersPage(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] string? role = null,
            [FromQuery] string? sortBy = null,
            [FromQuery] bool sortDescending = false,
            CancellationToken ct = default)
        {
            var query = new GetUserPageQuery(
                page,
                pageSize,
                search,
                role,
                sortBy,
                sortDescending);

            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }
    }
}