using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.Commands.Users.RegisterUser;
using TaskToTask.WebAPI.DTOs.Requests.Users;

namespace TaskToTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        
            // TODO: написать CRUD для управления пользователями
    }
}
