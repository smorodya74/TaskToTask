﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.Interfaces.Auth;
using TaskToTask.Application.MediatR.Auth.Commands;
using TaskToTask.Application.MediatR.Auth.Queries;
using TaskToTask.Application.Models.Responses.Users;
using TaskToTask.WebAPI.DTO.Requests.Users;

namespace TaskToTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromBody] RegisterUserRequest dto,
            CancellationToken ct)
        {
            var id = await mediator.Send(
                new RegisterUserCommand(
                    dto.Username, 
                    dto.Email, 
                    dto.Password, 
                    dto.ConfirmPassword), ct);

            return Ok(id);
        }
        
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest dto, CancellationToken ct)
        {
            var token = await mediator.Send(
                new LoginUserCommand(
                    dto.UsernameOrEmail,
                    dto.Password), ct);

            Response.Cookies.Append("session_token", token);

            return Ok("Вход выполнен");
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("session_token");

            return Ok("Выход выполнен");
        }

        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserResponse>> GetMe(
            [FromServices] IUserContext userContext,
            CancellationToken ct)
        {
            var userResponse = await mediator.Send(new GetMeQuery(userContext.UserId), ct);

            return Ok(userResponse);
        }
    }
}
