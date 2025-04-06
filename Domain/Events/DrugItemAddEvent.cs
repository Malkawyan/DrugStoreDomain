using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Event добавления нового товара
/// </summary>
internal class DrugItemAddEvent : IDomainEvent
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugId"></param>
    /// <param name="drugStoreId"></param>
    /// <param name="cost"></param>
    /// <param name="count"></param>
    internal DrugItemAddEvent(Guid drugId, Guid drugStoreId, decimal cost, double count)
    {
        _drugId = drugId;
        _drugStoreId = drugStoreId;
        _cost = cost;
        _count = count;
    }

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    private readonly Guid? _drugId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    private readonly Guid? _drugStoreId;

    /// <summary>
    /// Стоимость препарата
    /// </summary>
    private readonly decimal? _cost;

    /// <summary>
    /// Количество препарата
    /// </summary>
    private readonly double? _count;
}