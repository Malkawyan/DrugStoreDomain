using Ardalis.GuardClauses;
using Domain.Events;
using Domain.Primitives;
using Domain.Validators;

namespace Domain.Entities;

/// <summary>
/// Представляет информацию о наличии препарата в конкретной аптеке
/// </summary>
public class DrugItem : BaseEntity<DrugItem>
{
/// <summary>
/// Конструктор
/// </summary>
/// <param name="drugId"></param>
/// <param name="drugStoreId"></param>
/// <param name="cost"></param>
/// <param name="count"></param>
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, double count)
    {
        DrugId = Guard.Against.NullOrEmpty(drugId, nameof(drugId), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        DrugStoreId = Guard.Against.NullOrEmpty(drugStoreId, nameof(drugStoreId), ValidationMessage.NullOrWhiteSpaceOrEmpty);
        Cost = Guard.Against.NegativeOrZero(cost, nameof(cost),ValidationMessage.NegativeOrZero);
        Count = Guard.Against.NegativeOrZero(count, nameof(count), ValidationMessage.NegativeOrZero);

        var validator = new DrugItemValidator();

        validator.Validate(this);
        
        AddDomainEvent(new DrugItemAddEvent(DrugId, DrugStoreId, Cost, Count));
    }
    
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public Guid DrugId { get; private set; }
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid DrugStoreId { get; private set; }
    
    /// <summary>
    /// Стоимость препарата
    /// </summary>
    public decimal Cost { get; private set; }
    
    /// <summary>
    /// Количество препарата на складе
    /// </summary>
    public double Count { get; private set; }

    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; }
    
    
    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore DrugStore { get; private set; }

    #region Методы

    /// <summary>
    /// Изменение кол-ва товара
    /// 
    /// </summary>
    /// <param name="count"></param>
    public void UpdateCount(double count)
    {
        Count = count;

        ValidateEntity(new DrugItemValidator());
        
        AddDomainEvent(new DrugItemCountUpdatedEvent(Count));
    }
    
    /// <summary>
    /// Изменение цены товара
    /// </summary>
    /// <param name="cost"></param>
    public void UpdateCost(decimal cost)
    {
        Cost = cost;

        ValidateEntity(new DrugItemValidator());
        
        AddDomainEvent(new DrugItemCostUpdatedEvent(Cost));
    }

    /// <summary>
    /// Добавление товара
    /// </summary>
    /// <param name="drugId"></param>
    /// <param name="drugStoreId"></param>
    /// <param name="cost"></param>
    /// <param name="count"></param>
    public void AddDrugItem(Guid drugId, Guid drugStoreId, decimal cost, double count)
    {
        var drugItem = new DrugItem(drugId, drugStoreId, cost, count);
        
        ValidateEntity(new DrugItemValidator());
        
        AddDomainEvent(new DrugItemAddEvent(DrugId, DrugStoreId, Cost, Count));
    }

    /// <summary>
    /// Добавление товара в аптеку
    /// </summary>
    /// <param name="drugId"></param>
    /// <param name="drugStoreId"></param>
    /// <param name="cost"></param>
    /// <param name="count"></param>
    public void AddDrugToDrugStore(Guid drugId, Guid drugStoreId, decimal cost, double count)
    {
        var drugItem = new DrugItem(drugId, drugStoreId, cost, count);
        
        ValidateEntity(new DrugItemValidator());
        
        AddDomainEvent(new AddDrugToDrugStoreEvent(DrugId, DrugStoreId, Cost, Count));
    }

    /// <summary>
    /// Удаление товара
    /// </summary>
    public void DrugItemRemove(Guid drugId, Guid drugStoreId)
    {
        ValidateEntity(new DrugItemValidator());
        AddDomainEvent(new DrugItemRemoveEvent(DrugId, DrugStoreId));
    }
    
    
    #endregion
}