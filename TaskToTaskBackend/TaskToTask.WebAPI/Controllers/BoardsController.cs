using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskToTask.Application.MediatR.Boards.Commands;
using TaskToTask.Application.Models.Requests.Boards;

namespace TaskToTask.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardsController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost("board")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBoard([FromBody] CreateBoardRequest dto, CancellationToken ct)
    {
        var id = await mediator.Send(new CreateBoardCommand(dto.Title, dto.Description), ct);

        return Ok(id);
    }

    // TODO: при создании доски сделать проверку на описание, если нет - стандартное написать
    // TODO: дописать CRUD-методы для управления досками
}