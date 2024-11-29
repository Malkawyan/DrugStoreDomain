using Domain.Value_Objects;
using System.Collections.ObjectModel;

namespace Domain.Entities;

/// <summary>
/// Аптека
/// </summary>
public class DrugStore : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugNetwork"></param>
    /// <param name="number"></param>
    /// <param name="address"></param>
    public DrugStore(string drugNetwork, int number, Address address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
        DrugItems = new Collection<DrugItem>();
    }
    /// <summary>
    /// Сеть аптек
    /// </summary>
    public string DrugNetwork { get; private set; }
    /// <summary>
    /// Номер аптеки
    /// </summary>
    public int Number { get; private set; }
    /// <summary>
    /// Адрес аптеки
    /// </summary>
    public Address Address { get; private set; }
    
    /// <summary>
    /// Список препаратов, доступных в аптеке
    /// </summary>
    public Collection<DrugItem> DrugItems { get; private set; }
}