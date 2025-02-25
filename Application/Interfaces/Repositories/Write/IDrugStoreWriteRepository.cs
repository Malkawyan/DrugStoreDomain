using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Write репозиторий сущности DrugStore
/// </summary>
public interface IDrugStoreWriteRepository : IWriteRepository<DrugStore>
{
    Task UpdateDrugStoreAddressAsync(Guid id, string newAddress, CancellationToken cancellationToken);
}