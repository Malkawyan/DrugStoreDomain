using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация Country
/// </summary>
public class CountryValidator : AbstractValidator<Country>
{
    /// <summary>
    /// Бизнес-валидация Country
    /// </summary>
    public CountryValidator()
    {
        RuleFor(c => c.Name)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtMessage)
            .Matches("[A-Za-zА-Яа-яЁё\\s]+").WithMessage(ValidationMessage.MessageSymbols);
        
        RuleFor(c => c.Code)
            .Length(2).WithMessage(ValidationMessage.LengthMessageSingle)
            .Matches("[A-Z]+").WithMessage(ValidationMessage.MessageSymbols);
    }
}