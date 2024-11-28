namespace Domain.Entities;

/// <summary>
/// Представляет информацию о наличии препарата в конкретной аптеке
/// </summary>
public class DrugItem : BaseEntity
{
/// <summary>
/// Конструктор
/// </summary>
/// <param name="drugId"></param>
/// <param name="drugStoreId"></param>
/// <param name="cost"></param>
/// <param name="count"></param>
    public DrugItem(Guid drugId, Guid drugStoreId, decimal cost, int count)
    {
        DrugId = drugId;
        DrugStoreId = drugStoreId;
        Cost = cost;
        Count = count;
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
    public int Count { get; private set; }

    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore DrugStore { get; private set; }
}