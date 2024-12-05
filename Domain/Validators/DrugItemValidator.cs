using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

/// <summary>
/// Бизнес-валидация DrugItem
/// </summary>
public class DrugItemValidator : AbstractValidator<DrugItem>
{
    /// <summary>
    /// Бизнес-валидация DrugItem
    /// </summary>
    public DrugItemValidator()
    {
        RuleFor(di => di.Cost)
            .Must(cost => cost == Math.Round(cost, 2))
            .WithMessage(ValidationMessage.CostTooManyDecimalPlaces);

        RuleFor(di => di.Count)
            .Must(count => count == (int)count).WithMessage(ValidationMessage.IntCheck)
            .LessThanOrEqualTo(10000).WithMessage(ValidationMessage.MaxValueMessage);
    }
}