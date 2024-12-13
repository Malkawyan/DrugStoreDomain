using Domain.Value_Objects;
using System.Collections.ObjectModel;
using Ardalis.GuardClauses;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Аптека
/// </summary>
public class DrugStore : BaseEntity<DrugStore>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugNetwork"></param>
    /// <param name="number"></param>
    /// <param name="address"></param>
    public DrugStore(string drugNetwork, int number, Address address)
    {
        DrugNetwork = Guard.Against.NullOrWhiteSpace(drugNetwork, nameof(drugNetwork), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        Number = Guard.Against.NegativeOrZero(number, nameof(number), ValidationMessage.NegativeOrZero);
        Address = Guard.Against.Null(address, nameof(address), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        DrugItems = new Collection<DrugItem>();

        var validator = new DrugStoreValidator();

        validator.Validate(this);
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