using Domain.Entities;
namespace Application.Interfaces.Repositories.Read;
using Domain.Value_Objects;

/// <summary>
/// Read репозиторий сущности DrugStore
/// </summary>
public interface IDrugStoreReadRepository : IReadRepository<DrugStore>
{
    Task<List<DrugStore>> SearchDrugStoreByAddress(Address address, CancellationToken cancellationToken);
    Task<List<DrugStore>> GetDrugStoresByNetworkAsync(string drugNetwork, CancellationToken cancellationToken);
}