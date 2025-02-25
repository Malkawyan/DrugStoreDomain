using Domain.Interfaces;
using Domain.Entities;

namespace Domain.Events;

/// <summary>
/// Event создания препарата
/// </summary>
internal class DrugCreatedEvent : IDomainEvent
{
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"></param>
    /// <param name="manufacturer"></param>
    /// <param name="countryCode"></param>
    /// <param name="country"></param>
    internal DrugCreatedEvent(string name, string manufacturer, string countryCode, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCode = countryCode;
        Country = country;
    }

    /// <summary>
    /// Название препарата
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public string CountryCode { get; }
    
    /// <summary>
    /// Страна
    /// </summary>
    public Country Country { get; }
}
