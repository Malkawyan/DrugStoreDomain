namespace Domain.Events;
using Domain.Interfaces;
using Domain.Entities;

/// <summary>
/// Event обновления препарата
/// </summary>
internal class DrugUpdatedEvent : IDomainEvent
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"></param>
    /// <param name="manufacturer"></param>
    /// <param name="countryCode"></param>
    /// <param name="country"></param>
    internal DrugUpdatedEvent(string name, string manufacturer, string countryCode, Country country)
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