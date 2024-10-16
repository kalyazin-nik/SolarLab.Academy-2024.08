using FluentValidation;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.Account.Validator;

public class UserLoginRequestValidator : AbstractValidator<UserLoginRequestDto>
{
    public UserLoginRequestValidator()
    {
        RuleFor(x => x).NotNull().WithMessage("Запрос не может быть пустым.");

        RuleFor(x => x.Login).NotNull().NotEmpty().WithMessage("'Login' не может быть пустым.");

        RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("'Password' не может быть пустым.");
    }
}
