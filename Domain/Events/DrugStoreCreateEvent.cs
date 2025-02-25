namespace Domain.Event;
using Domain.Interfaces;
using Domain.Value_Objects;

/// <summary>
/// Event создания аптеки
/// </summary>
internal class DrugStoreCreatedEvent : IDomainEvent
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugNetwork"></param>
    /// <param name="number"></param>
    /// <param name="address"></param>
    internal DrugStoreCreatedEvent(string drugNetwork, int number, Address address)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
    }

    /// <summary>
    /// Сеть аптек
    /// </summary>
    public string DrugNetwork { get; }
    
    /// <summary>
    /// Номер аптеки в сети
    /// </summary>
    public int Number { get; }
    
    /// <summary>
    /// Адрес 
    /// </summary>
    public Address Address { get; }
}