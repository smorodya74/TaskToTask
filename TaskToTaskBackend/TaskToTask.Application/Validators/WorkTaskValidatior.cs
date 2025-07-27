using FluentValidation;
using TaskToTask.Application.Validators.Base;
using TaskToTask.Domain.Models;

namespace TaskToTask.Application.Validators;

public class WorkTaskValidatior : AbstractValidator<WorkTask>
{
    public WorkTaskValidatior()
    {
        RuleFor(task => task.Title)
            .SetValidator(new TitleValidator());

        RuleFor(task => task.Description)
            .SetValidator(new DescriptionValidator());
    }
}