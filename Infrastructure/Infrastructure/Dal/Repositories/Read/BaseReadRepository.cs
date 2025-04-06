using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories.Read;

/// <summary>
/// Базовый read репозиторий
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseReadRepository<T>(DbContext context) : IReadRepository<T>
    where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    /// <summary>
    /// Получение сущности по Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync([id], cancellationToken);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Сущность {typeof(T).Name} с Id {id} не найдена!");
        }
        return entity;
    }
    
    /// <summary>
    /// Получить IQueryable с применением OData
    /// </summary>
    /// <param name="oDataQueryOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<IQueryable<T>> GetQueryableAsync(ODataQueryOptions<T> oDataQueryOptions, CancellationToken cancellationToken)
    {
        // TODO: Добавить поиск
        throw new NotImplementedException();
    }
    
    
    /// <summary>
    /// Найти сущности, удовлетворяющие условию
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        var entitys = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        
        return entitys;
    }
}