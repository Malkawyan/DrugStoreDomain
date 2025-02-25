using System.Collections.ObjectModel;
using System.Diagnostics;
using Ardalis.GuardClauses;
using Domain.Events;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Препарат
/// </summary>
public class Drug : BaseEntity<Drug>
{

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"></param>
    public Drug(string name, string manufacturer, string countrycodeid, Country country, Func<string, bool> countryExistsFunc)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        Manufacturer = Guard.Against.NullOrWhiteSpace(manufacturer, nameof(manufacturer), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        CountryCodeId = Guard.Against.NullOrWhiteSpace(countrycodeid, nameof(countrycodeid), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        Country = Guard.Against.Null(country, nameof(country), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        DrugItems = new Collection<DrugItem>();

        var validator = new DrugValidator();
        
        validator.Validate(this);
        AddDomainEvent(new DrugCreatedEvent(name, manufacturer, countrycodeid, country));
        
    }

    /// <summary>
    /// Название препарата 
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

    #region  Методы
    /// <summary>
    /// Обновление Drug
    /// </summary>
    /// <param name="name"></param>
    /// <param name="manufacturer"></param>
    /// <param name="countrycodeid"></param>
    /// <param name="country"></param>
    public void UpdateDrug(string name, string manufacturer, string countrycodeid, Country country)
    {
        ValidateEntity(new DrugValidator());
        
        AddDomainEvent(new DrugUpdatedEvent(name, manufacturer, countrycodeid, country));
    }

    #endregion

}