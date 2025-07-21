using FluentValidation;
using TaskToTask.Application.MediatR.Auth.Commands;
using TaskToTask.Application.Validators.Base;

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
                .SetValidator(new EmailValidator());

            RuleFor(user => user.Password)
                .SetValidator(new PasswordValidator());

            RuleFor(user => user.ConfirmPassword)
                .Equal(user => user.Password)
                .WithMessage("Пароли не совпадают");
        }
    }
}
