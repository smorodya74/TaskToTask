using FluentValidation;
using TaskToTask.Application.MediatR.Users.Commands;
using TaskToTask.Application.Validators.Base;

namespace TaskToTask.Application.Validators;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(user => user.NewPassword)
            .SetValidator(new PasswordValidator());
        
        RuleFor(user => user.ConfirmNewPassword)
            .Equal(user => user.NewPassword)
            .WithMessage("Пароли не совпадают");
    }
}