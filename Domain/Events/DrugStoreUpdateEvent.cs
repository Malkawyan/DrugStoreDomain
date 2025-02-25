namespace Domain.Events;
using Domain.Interfaces;
using Domain.Value_Objects;

/// <summary>
/// Событие обновления аптеки
/// </summary>
public class DrugStoreUpdatedEvent : IDomainEvent
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugNetwork"></param>
    /// <param name="number"></param>
    /// <param name="address"></param>
    public DrugStoreUpdatedEvent(string drugNetwork, int number, Address address)
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
    /// Адрес аптеки
    /// </summary>
    public Address Address { get; }
}