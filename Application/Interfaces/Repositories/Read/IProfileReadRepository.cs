using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;


/// <summary>
/// Read репозиторий сущности Profile
/// </summary>
public interface IProfileReadRepository : IReadRepository<Profile>
{
    Task<Profile?> GetProfileByExternalIdAsync(string externalId, CancellationToken cancellationToken);
}