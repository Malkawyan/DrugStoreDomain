using Microsoft.AspNetCore.OData.Query;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Общий Read репозиторий
/// </summary>
public interface IReadRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<IQueryable<T>> GetQueryableAsync(ODataQueryOptions<T> oDataQueryOptions, CancellationToken cancellationToken);
}