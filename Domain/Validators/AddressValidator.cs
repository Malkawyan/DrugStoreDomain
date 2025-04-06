using FluentValidation;
using Domain.Value_Objects;
using Domain.Primitives;

namespace Domain.Validators;

/// <summary>
/// Валидация Address
/// </summary>
public sealed class AddressValidator : AbstractValidator<Address>
{
    /// <summary>
    /// Валидация
    /// </summary>
    public AddressValidator()
    {
        // Валидация для City
        RuleFor(a => a.City)
            .NotEmpty().WithMessage(ValidationMessage.NullOrWhiteSpaceOrEmpty)
            .Length(2, 50).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"^[A-Za-z\s\-]+$").WithMessage(ValidationMessage.MessageNoSymbols);

        // Валидация для Street
        RuleFor(a => a.Street)
            .NotEmpty().WithMessage(ValidationMessage.NullOrWhiteSpaceOrEmpty)
            .Length(3, 100).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"^[A-Za-z0-9\s\-]+$").WithMessage(ValidationMessage.MessageNoSymbols);

        // Валидация для House
        RuleFor(a => a.House)
            .NotEmpty().WithMessage(ValidationMessage.NullOrWhiteSpaceOrEmpty)
            .Length(1, 10).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"^[A-Za-z0-9\-]+$").WithMessage(ValidationMessage.MessageNoSymbols);
    }
}