using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .Length(2, 150).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"[A-Z]").WithMessage(ValidationMessage.LenghtMessage);
    }
}