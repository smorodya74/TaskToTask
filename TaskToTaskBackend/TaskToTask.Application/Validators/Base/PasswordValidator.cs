using FluentValidation;

namespace TaskToTask.Application.Validators.Base;

public class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator()
    {
        RuleFor(password => password)
            .NotEmpty().WithMessage("Пароль не может быть пустым.")
            .Length(8-254).WithMessage("Пароль должен содержать от 8 до 254 символов.")
            .Matches("[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву (A-Z).")
            .Matches("[a-z]").WithMessage("Пароль должен содержать хотя бы одну строчную букву (a-z).")
            .Matches("[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру (0-9).")
            .Matches("[^a-zA-Z0-9]").WithMessage("Пароль должен содержать хотя бы один спецсимвол (например, ! @ # $ % ^ & *).")
            .Matches("^[a-zA-Z0-9!@#$%^&*]+$").WithMessage("Пароль может содержать только A-Z, 0-9 и спецсимволы (! @ # $ % ^ & *).");
    }
}