using Domain.Interfaces;

namespace Domain.Events;

/// <summary>
/// Обновление DrugItem
/// </summary>
internal class DrugItemCountUpdatedEvent : IDomainEvent
{
    /// <summary>
    /// Кол-во
    /// </summary>
    private readonly double? _count;
    
    /// <summary>
    /// Событие обновления DrugItem
    /// </summary>
    /// <param name="count"></param>
    internal DrugItemCountUpdatedEvent(double? count)
    {
        _count = count;
    }
}