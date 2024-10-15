using FluentValidation;
using FluentValidation.Validators;
using Serilog;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.User.Validator;

public class UserRegisterValidator : AbstractValidator<UserRegisterRequestDto>
{
    private readonly static HashSet<int> _uppercaseCharacters = new(Enumerable.Range(65, 26));
    private readonly static HashSet<int> _lowercaseCharacters = new(Enumerable.Range(97, 26));
    private readonly static HashSet<int> _numberSymbols = new(Enumerable.Range(48, 10));
    private readonly static HashSet<char> _specialCharacters = ['!', '#', '$', '%', '&', '(', ')', '*', '/', '?', '@', '{', '}'];
    private const int MinimumPasswordLength = 8;
    private const int MinimumAge = 18;
    private const int MaximumAge = 90;

    public UserRegisterValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("Модель регистрации не должна быть пустой.");

        RuleFor(x => x.Name)
            .NotNull().WithMessage("Имя обязательно к заполнению.")
            .NotEmpty().WithMessage("Имя обязательно к заполнению.");

        CheckLogin();
        CheckPassword();

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Электронная почта обязательна к заполнению.")
            .NotEmpty().WithMessage("Электронная почта обязательна к заполнению.")
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Неверный электронный адрес.");

        RuleFor(x => x.BirthDate)
            .NotNull().WithMessage("Дата рождения обязательна к заполнению.")
            .NotEmpty().WithMessage("Дата рождения обязательна к заполнению.")
            .Must(birthDate => birthDate < DateTime.Now.AddYears(-MinimumAge)).WithMessage("На платформе возможно зарегистрироваться только с 18 лет.")
            .Must(birthDate => birthDate > DateTime.Now.AddYears(-MaximumAge)).WithMessage("Возраст участника платформы не может превышать 90 лет.");
    }

    private void CheckLogin()
    {
        RuleFor(x => x.Login)
            .NotNull().WithMessage("Логин обязателен к заполнению.")
            .NotEmpty().WithMessage("Логин обязателен к заполнению.")
            .Must(login =>
            {
                if (string.IsNullOrEmpty(login))
                    return false;

                foreach (var character in login)
                {
                    if (_uppercaseCharacters.Contains(character) || _lowercaseCharacters.Contains(character) || _numberSymbols.Contains(character) || character is '_') { }
                    else return false;
                }

                return true;
            }).WithMessage("Логин должен быть из букв латинского алфавита, а так же может содержать цифры и символ нижнего подчеркивания.");
    }

    private void CheckPassword()
    {
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Пароль обязателен к заполнению.")
            .NotEmpty().WithMessage("Пароль обязателен к заполнению.")

            .Must(x => x?.Length >= MinimumPasswordLength)
                .WithMessage(string.Format("Минимальная длина пароля должна составлять {0} символов.", MinimumPasswordLength))

            .Must(password =>
            {
                if (string.IsNullOrEmpty(password))
                    return false;

                var upperCaseExist = false;
                var lowerCaseExist = false;
                foreach (var character in password)
                {
                    if (_uppercaseCharacters.Contains(character)) upperCaseExist = true;
                    else if (_lowercaseCharacters.Contains(character)) lowerCaseExist = true;
                    if (upperCaseExist && lowerCaseExist) return true;
                }

                return false;
            }).WithMessage("Пароль должен содержать строчные и прописные символы латиницы. A-Z a-z")

            .Must(password =>
            {
                if (string.IsNullOrEmpty(password))
                    return false;

                foreach (var character in password)
                    if (_numberSymbols.Contains(character)) return true;

                return false;
            }).WithMessage("Пароль должен содержать цифры. 0-9")

            .Must(password =>
            {
                if (string.IsNullOrEmpty(password))
                    return false;

                foreach (var character in password)
                    if (_specialCharacters.Contains(character)) return true;

                return false;
            }).WithMessage(string.Format("Пароль должен содержать специальные символы. {0}", string.Join(" ", _specialCharacters)));
    }
}
