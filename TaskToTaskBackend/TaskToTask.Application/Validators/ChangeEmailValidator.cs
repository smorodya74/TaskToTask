using FluentValidation;
using TaskToTask.Application.MediatR.Users.Commands;
using TaskToTask.Application.Validators.Base;

namespace TaskToTask.Application.Validators;

public class ChangeEmailValidator : AbstractValidator<ChangeEmailCommand>
{
    public ChangeEmailValidator()
    {
        RuleFor(user => user.NewEmail)
            .SetValidator(new EmailValidator());
    }
}