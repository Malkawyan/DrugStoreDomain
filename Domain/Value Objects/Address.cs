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
    public Address(string street, string city, string house)
    {
        Street = street;
        City = city;
        House = house;
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
    /// Переопределение ToString()
    /// </summary>
    /// <returns></returns>

    public override string ToString()
    {
        return $"{City}, {Street}, {House}";
    }
    
}