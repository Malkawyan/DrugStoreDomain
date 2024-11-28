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
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countrycodeid;
        DrugItems = new List<DrugItem>();
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
    public List<DrugItem> DrugItems { get; private set; }

}