using CSharpFunctionalExtensions;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;
public abstract class Repository<TEntity, TEntityId>
    where TEntity : BaseEntity<TEntityId>
    where TEntityId : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual Task<Maybe<TEntity>> GetByIdAsync(TEntityId id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<TEntity>()
            .SingleOrDefaultAsync(e => e.Id == id, cancellationToken)
            .AsMaybe();
    }

    public virtual Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<TEntity>()
            .ToListAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }
}
