using Domain.Entities;

namespace Application.Interfaces.Repositories.Read;

/// <summary>
/// Read репозиторий сущности Country
/// </summary>
public interface ICountryReadRepository : IReadRepository<Country>
{
    Task<List<Country>> SearchCountriesByNameAsync(string name, CancellationToken cancellationToken);
}