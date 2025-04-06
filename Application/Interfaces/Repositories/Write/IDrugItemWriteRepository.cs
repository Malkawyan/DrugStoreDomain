using Domain.Entities;
namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Write репозиторий сущности DrugItem
/// </summary>
public interface IDrugItemWriteRepository : IWriteRepository<DrugItem>
{
    Task UpdateDrugItemPriceAsync(Guid id, decimal newPrice, CancellationToken cancellationToken);
}