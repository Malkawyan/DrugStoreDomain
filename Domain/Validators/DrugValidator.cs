using Domain.Entities;
using Domain.Primitives;
using FluentValidation;
using System.Globalization;

namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация Drug
/// </summary>
public class DrugValidator : AbstractValidator<Drug>
{
    /// <summary>
    /// Валидация Drug
    /// </summary>
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .Length(2, 150).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"[^\W_]+$").WithMessage(ValidationMessage.MessageNoSymbols);
        
        RuleFor(d=>d.Manufacturer)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"[A-Za-zА-Яа-яЁё\s-]+$").WithMessage(ValidationMessage.MessageSymbols);
        
        RuleFor(d=>d.CountryCodeId)
            .Length(2).WithMessage(ValidationMessage.LengthMessageSingle)
            .Matches("[A-Z]+").WithMessage(ValidationMessage.MessageSymbols)
            .Must(ValidCountryCode.IsValidCountryCode).WithMessage(ValidationMessage.Iso);
    }

}