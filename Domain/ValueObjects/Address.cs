using Ardalis.GuardClauses;
using Domain.Primitives;

namespace Domain.Value_Objects;

/// <summary>
/// Адрес аптеки
/// </summary>
public class Address : BaseValueObject
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="street"></param>
    /// <param name="city"></param>
    /// <param name="house"></param>
    public Address(string street, string city, string house, int postalCode, string country)
    {
        Street = Guard.Against.NullOrWhiteSpace(street, nameof(street), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        City = Guard.Against.NullOrWhiteSpace(city, nameof(city), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        House = Guard.Against.NullOrWhiteSpace(house, nameof(house), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        PostalCode = Guard.Against.NegativeOrZero(postalCode, nameof(postalCode), ValidationMessage.NegativeOrZero);
        Country = Guard.Against.NullOrWhiteSpace(country, nameof(country), ValidationMessage.NullOrWhiteSpaceOrEmpty);
    }
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }
    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }
    /// <summary>
    /// Дом
    /// </summary>
    public string House { get; private set; }
    
    /// <summary>
    /// Почтовый индекс
    /// </summary>
    public int PostalCode { get; private set; }
    
    /// <summary>
    /// ISO код страны
    /// </summary>
    public string Country { get; private set; }
    
    /// <summary>
    /// Переопределение ToString()
    /// </summary>
    /// <returns></returns>

    public override string ToString()
    {
        return $"{City}, {Street}, {House}";
    }
    
}