# Domain Event Handlers

## DrugItemAddEventHandler
```csharp

namespace Domain.EventHandlers
{
    /// <summary>
    /// Обработчик события добавления нового товара
    /// </summary>
    public class DrugItemAddEventHandler : INotificationHandler<DrugItemAddEvent>
    {
        private readonly IDrugItemRepository _drugItemRepository;  

        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="drugItemRepository"></param>
        public DrugItemAddEventHandler(IDrugItemRepository drugItemRepository)
        {
            _drugItemRepository = drugItemRepository;
        }

        /// <summary>
        /// Обработка события добавления нового товара
        /// </summary>
        public async Task Handle(DrugItemAddEvent notification, CancellationToken cancellationToken)
        {
            var drugItem = new DrugItem(notification._drugId.Value, notification._drugStoreId.Value, notification._cost.Value, notification._count.Value);
            await _drugItemRepository.AddAsync(drugItem, cancellationToken);
        }
    }
}
```

## DrugItemCostUpdatedEvent
```csharp
namespace Domain.EventHandlers
{
    /// <summary>
    /// Обработчик события обновления стоимости товара
    /// </summary>
    public class DrugItemCostUpdatedEventHandler : INotificationHandler<DrugItemCostUpdatedEvent>
    {
        private readonly IDrugItemRepository _drugItemRepository;  // Репозиторий для работы с данными

        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="drugItemRepository"></param>
        public DrugItemCostUpdatedEventHandler(IDrugItemRepository drugItemRepository)
        {
            _drugItemRepository = drugItemRepository;
        }

        /// <summary>
        /// Обработка события обновления стоимости товара
        /// </summary>
        /// <param name="notification">Событие обновления стоимости товара</param>
        /// <param name="cancellationToken">Токен отмены</param>
        public async Task Handle(DrugItemCostUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var drugItem = await _drugItemRepository.GetByCostAsync(notification._cost.Value, cancellationToken);

            if (drugItem != null)
            {
                drugItem.UpdateCost(notification._cost.Value);

                await _drugItemRepository.UpdateAsync(drugItem, cancellationToken);

            }
            else
            {
                Console.WriteLine($"Товар с указанной стоимостью {notification._cost.Value} не найден.");
            }
        }
    }
}

```

## DrugItemCountUpdatedEvent
```csharp

namespace Domain.EventHandlers
{
    /// <summary>
    /// Обработчик события обновления количества товара
    /// </summary>
    public class DrugItemCountUpdatedEventHandler : INotificationHandler<DrugItemCountUpdatedEvent>
    {
        private readonly IDrugItemRepository _drugItemRepository;  // Репозиторий для работы с данными

        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="drugItemRepository"></param>
        public DrugItemCountUpdatedEventHandler(IDrugItemRepository drugItemRepository)
        {
            _drugItemRepository = drugItemRepository;
        }

        /// <summary>
        /// Обработка события обновления количества товара
        /// </summary>
        /// <param name="notification">Событие обновления количества товара</param>
        /// <param name="cancellationToken">Токен отмены</param>
        public async Task Handle(DrugItemCountUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var drugItem = await _drugItemRepository.GetByCountAsync(notification._count.Value, cancellationToken);

            if (drugItem != null)
            {
                drugItem.UpdateCount(notification._count.Value);

                await _drugItemRepository.UpdateAsync(drugItem, cancellationToken);

            }
            else
            {

                Console.WriteLine($"Товар с указанным количеством {notification._count.Value} не найден.");
            }
        }
    }
}
```

## DrugItemRemoveEvent
```csharp

namespace Domain.EventHandlers
{
    /// <summary>
    /// Обработчик события удаления товара
    /// </summary>
    public class DrugItemRemoveEventHandler : INotificationHandler<DrugItemRemoveEvent>
    {
        private readonly IDrugItemRepository _drugItemRepository;  // Репозиторий для работы с данными

        /// <summary>
        /// Конструктор обработчика
        /// </summary>
        /// <param name="drugItemRepository"></param>
        public DrugItemRemoveEventHandler(IDrugItemRepository drugItemRepository)
        {
            _drugItemRepository = drugItemRepository;
        }

        /// <summary>
        /// Обработка события удаления товара
        /// </summary>
        /// <param name="notification">Событие удаления товара</param>
        /// <param name="cancellationToken">Токен отмены</param>
        public async Task Handle(DrugItemRemoveEvent notification, CancellationToken cancellationToken)
        {
            var drugItem = await _drugItemRepository.GetByIdsAsync(notification._drugId.Value, notification._drugStoreId.Value, cancellationToken);

            if (drugItem != null)
            {
                await _drugItemRepository.RemoveAsync(drugItem, cancellationToken);
            }
            else
            {
                Console.WriteLine($"Товар с ID {notification._drugId} в аптеке с ID {notification._drugStoreId} не найден.");
            }
        }
    }
}
```