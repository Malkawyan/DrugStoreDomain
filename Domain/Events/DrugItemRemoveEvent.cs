using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Event удаления продукта
/// </summary>
internal class DrugItemRemoveEvent : IDomainEvent
{

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    private readonly Guid? _drugId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    private readonly Guid? _drugStoreId;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugId"></param>
    /// <param name="drugStoreId"></param>
    internal DrugItemRemoveEvent(Guid? drugId, Guid? drugStoreId)
    {
        _drugId = drugId;
        _drugStoreId = drugStoreId;
    }

}