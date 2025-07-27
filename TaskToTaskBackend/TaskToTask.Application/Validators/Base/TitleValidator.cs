using FluentValidation;

namespace TaskToTask.Application.Validators.Base;

public class TitleValidator : AbstractValidator<string>
{
    public TitleValidator()
    {
        RuleFor(title => title)
            .NotEmpty().WithMessage("Название обязательно к заполнению.")
            .Length(3, 64).WithMessage("Название должно иметь длину от 3 до 64 символов.");
    }
}