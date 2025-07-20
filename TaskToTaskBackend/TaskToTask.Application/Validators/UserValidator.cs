using FluentValidation;
using TaskToTask.Application.MediatR.Auth.Commands;

namespace TaskToTask.Application.Validators
{
    public class UserValidator : AbstractValidator<RegisterUserCommand>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Имя пользователя обязательное поле.")
                .Length(5, 64).WithMessage("Имя пользователя должно содержать от 5 до 64 символов.")
                .Matches("^[a-zA-z0-9_]+$").WithMessage("Допускаются символы: A-Z, a-z, 0-9 и \"_\".");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email не может быть пустым.")
                .EmailAddress().WithMessage("Некорректный формат email. Пример: example@example.xyz");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Пароль не может быть пустым.")
                .Length(8-254).WithMessage("Пароль должен содержать от 8 до 254 символов.")
                .Matches("[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву (A-Z).")
                .Matches("[a-z]").WithMessage("Пароль должен содержать хотя бы одну строчную букву (a-z).")
                .Matches("[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру (0-9).")
                .Matches("[^a-zA-Z0-9]").WithMessage("Пароль должен содержать хотя бы один спецсимвол (например, ! @ # $ % ^ & *).")
                .Matches("^[a-zA-Z0-9!@#$%^&*]+$").WithMessage("Пароль может содержать только A-Z, 0-9 и спецсимволы (! @ # $ % ^ & *).");

            RuleFor(user => user.ConfirmPassword)
                .Equal(user => user.Password)
                .WithMessage("Пароли не совпадают");
        }
    }
}
