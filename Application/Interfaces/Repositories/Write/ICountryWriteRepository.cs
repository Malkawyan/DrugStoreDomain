using Domain.Entities;

namespace Application.Interfaces.Repositories.Write;

/// <summary>
/// Write репозиторий сущности Country
/// </summary>
public interface ICountryWriteRepository : IWriteRepository<Country>
{
    Task UpdateCountryNameAsync(Guid id, string newName, CancellationToken cancellationToken);
}