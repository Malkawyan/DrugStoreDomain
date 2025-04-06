using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Read репозиторий сущности Drug
/// </summary>
public interface IDrugReadRepository : IReadRepository<Drug>
{
    Task<List<Drug>> SearchDrugsByName(string name, CancellationToken cancellationToken);
    Task<List<Drug>> SearchDrugsByManufacturerAsync(string manufacturerName, CancellationToken cancellationToken);
}