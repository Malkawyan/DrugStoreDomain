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
    public Drug(string name)
    {
        Name = name;
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
}