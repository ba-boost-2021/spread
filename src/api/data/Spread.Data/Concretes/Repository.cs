using Spread.Data.Abstractions;
using System.Linq.Expressions;

namespace Spread.Data.Concretes;

internal class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DbContext dbContext;

    public Repository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Delete(Guid id)
    {
        var entity = Get(id);
        entity.IsDeleted = true;
        Update(entity);
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
        Update(entity);
    }

    public Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().SingleOrDefaultAsync(f => f.Id == id, cancellationToken);
    }

    public Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().SingleOrDefaultAsync(predicate);
    }

    public Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<PagedList<T>> GetPagedList(Expression<Func<T, bool>> predicate, PageRequest pageRequest, CancellationToken cancellationToken)
    {
        var query = dbContext.Set<T>().Where(predicate);
        var count = await query.CountAsync(cancellationToken);
        query = query.Skip(pageRequest.PageSize * (pageRequest.PageNumber - 1)).Take(pageRequest.PageSize);
        var result = await query.ToListAsync(cancellationToken);
        return new PagedList<T>
        {
            Items = result,
            PageSize = pageRequest.PageSize,
            TotalCount = count
        };
    }

    public void Insert(T entity)
    {
        entity.IsActive = true;
        entity.IsDeleted = false;
        entity.CreatedAt = DateTime.Now;
        entity.ModifiedAt = DateTime.Now;
        dbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        entity.ModifiedAt = DateTime.Now;
        dbContext.Set<T>().Update(entity);
    }
}
