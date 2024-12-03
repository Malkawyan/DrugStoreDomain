using System.Collections.ObjectModel;
using System.Diagnostics;
using Ardalis.GuardClauses;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Препарат
/// </summary>
public class Drug : BaseEntity
{

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"></param>
    public Drug(string name, string manufacturer, string countrycodeid)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Manufacturer = Guard.Against.NullOrWhiteSpace(manufacturer, nameof(manufacturer));
        CountryCodeId = Guard.Against.NullOrWhiteSpace(countrycodeid, nameof(countrycodeid));
        DrugItems = new Collection<DrugItem>();

        var validator = new DrugValidator();
        
        validator.Validate(this);
    }

    /// <summary>
    /// Имя 
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; private set; }

    /// <summary>
    /// Код страны
    /// </summary>
    public string CountryCodeId { get; private set; }

    /// <summary>
    /// Страна производителя
    /// </summary>
    public Country Country { get; private set; }

    /// <summary>
    /// Список связей между аптекой и препаратом 
    /// </summary>
    public Collection <DrugItem> DrugItems { get; private set; }

}