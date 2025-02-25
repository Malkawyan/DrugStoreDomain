using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Read репозиторий сущности DrugItem
/// </summary>
public interface IDrugItemReadRepository : IReadRepository<DrugItem>
{
    Task<List<DrugItem>> GetDrugItemsByStoreIdAsync(Guid drugStoreId, CancellationToken cancellationToken);
}