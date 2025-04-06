using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Write репозиторий сущности Profile
/// </summary>
public interface IProfileWriteRepository : IWriteRepository<Profile>
{
    Task UpdateEmailAsync(Guid id, string newEmail, CancellationToken cancellationToken);
}