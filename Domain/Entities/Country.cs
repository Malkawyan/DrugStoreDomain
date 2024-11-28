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
    public List<string> Drugs { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    public Country(string name, string code)
    {
        Name = name;
        Code = code;
        Drugs = new List<string>();
    }
}