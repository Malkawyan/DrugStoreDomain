using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Write репозиторий сущности FavoriteDrug
/// </summary>

public interface IFavoriteDrugWriteRepository : IWriteRepository<FavoriteDrug>
{
    Task RemoveFavoriteDrugAsync(Guid profileId, Guid drugId, CancellationToken cancellationToken);
}