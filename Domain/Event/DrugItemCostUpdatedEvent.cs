using Domain.Interfaces;

namespace Domain.Event;

/// <summary>
/// Обновление DrugItem
/// </summary>
internal class DrugItemCostUpdatedEvent : IDomainEvent
{
    /// <summary>
    /// Кол-во
    /// </summary>
    private readonly decimal? _cost;
    
    /// <summary>
    /// Событие обновления DrugItem
    /// </summary>
    /// <param name="cost"></param>
    internal DrugItemCostUpdatedEvent(decimal? cost)
    {
        _cost = cost;
    }
}