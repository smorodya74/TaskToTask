using FluentValidation;

namespace TaskToTask.Application.Validators.Base;

public class DescriptionValidator :  AbstractValidator<string>
{
    public DescriptionValidator()
    {
        RuleFor(description => description)
            .MaximumLength(500).WithMessage("Описание должно иметь длину до 500 символов.");
    }
}