using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Справочник стран
/// </summary>
public class Country : BaseEntity
{
    /// <summary>
    /// Название страны
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; private set; }
    
    /// <summary>
    ///  Список препаратов, связанных с этой страной.
    /// </summary>
    public Collection<Drug> Drugs { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    public Country(string name, string code)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        Code = Guard.Against.NullOrWhiteSpace(code, nameof(code), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        Drugs = new Collection<Drug>();

        var validator = new CountryValidator();

        validator.Validate(this);
    }
}