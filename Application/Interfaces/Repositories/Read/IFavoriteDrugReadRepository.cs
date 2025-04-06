using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Read репозиторий сущности FavoriteDrug
/// </summary>

public interface IFavoriteDrugReadRepository : IReadRepository<FavoriteDrug>
{
    Task<List<FavoriteDrug>> GetFavoriteDrugsByProfileIdAsync(Guid profileId, CancellationToken cancellationToken);
}