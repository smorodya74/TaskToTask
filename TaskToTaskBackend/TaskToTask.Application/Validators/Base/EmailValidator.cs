using FluentValidation;

namespace TaskToTask.Application.Validators.Base;

public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator()
    {
        RuleFor(email => email)
            .NotEmpty().WithMessage("Email не может быть пустым.")
            .MaximumLength(254).WithMessage("Длина Email должна быть менее 254 символов")
            .EmailAddress().WithMessage("Некорректный формат email. Пример: example@example.xyz");
    }
}