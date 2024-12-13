using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация DrugStore
/// </summary>
public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    /// <summary>
    /// Бизнес-валидация DrugStore
    /// </summary>
    public DrugStoreValidator()
    {
        RuleFor(ds => ds.DrugNetwork)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtMessage);
        
        RuleFor(ds => ds.Number)
            .Must(count => count == (int)count).WithMessage(ValidationMessage.IntCheck);
        
        RuleFor(ds => ds.Address.Street)
            .Length(3, 100).WithMessage(ValidationMessage.LenghtMessage);
        
        RuleFor(ds => ds.Address.City)
            .Length(2, 50).WithMessage(ValidationMessage.LenghtMessage);
        
        RuleFor(ds => ds.Address.PostalCode)
            .Must(count => count == (int)count).WithMessage(ValidationMessage.IntCheck);
        RuleFor(ds=>ds.Address.PostalCode.ToString())
            .Length(5, 6).WithMessage(ValidationMessage.LenghtMessage);
        
        RuleFor(ds=>ds.Address.Country)
            .Must(ValidCountryCode.IsValidCountryCode).WithMessage(ValidationMessage.Iso);
    }
    
}