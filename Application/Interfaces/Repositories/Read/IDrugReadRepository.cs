using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

public interface IDrugReadRepository : IReadRepository<Drug>
{
    Task<List<Drug>> SearchDrugsByManufacturerAsync(string manufacturerName, CancellationToken cancellationToken);
}