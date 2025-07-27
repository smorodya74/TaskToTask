using FluentValidation;
using TaskToTask.Application.MediatR.Boards.Commands;
using TaskToTask.Application.Validators.Base;

namespace TaskToTask.Application.Validators
{
    public class BoardValidator : AbstractValidator<CreateBoardCommand>
    {
        public BoardValidator()
        {
            RuleFor(board => board.Title)
                .SetValidator(new TitleValidator());

            RuleFor(board => board.Description)
                .SetValidator(new  DescriptionValidator());
        }
    }
}
