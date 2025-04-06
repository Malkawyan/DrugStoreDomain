using System.Linq.Expressions;

namespace Application.Interfaces.Repositories;


/// <summary>
/// Общий Write репозиторий
/// </summary>
public interface IWriteRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    
    void Update(T entity);
    
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}