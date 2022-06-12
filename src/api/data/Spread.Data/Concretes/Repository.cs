using AutoMapper;
using AutoMapper.QueryableExtensions;
using Spread.Data.Abstractions;
using System.Linq.Expressions;

namespace Spread.Data.Concretes;

internal class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DbContext dbContext;
    private readonly IMapper mapper;
    private readonly IClaims claims;

    public Repository(DbContext dbContext, IMapper mapper, IClaims claims)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        this.claims = claims;
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

    public Task<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().Where(predicate).ProjectTo<TDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }

    public Task<List<TDto>> GetAll<TDto>(Expression<Func<T, bool>> predicate, Expression<Func<TDto, object>> order, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().Where(predicate).ProjectTo<TDto>(mapper.ConfigurationProvider).OrderBy(order).ToListAsync(cancellationToken);
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
        if (claims.IsAuthenticated)
        {
            entity.CreatedBy = claims.CurrentUser.Id;
            entity.ModifiedBy = claims.CurrentUser.Id;
        }
        dbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        entity.ModifiedAt = DateTime.Now;
        if (claims.IsAuthenticated)
        {
            entity.ModifiedBy = claims.CurrentUser.Id;
        }
        dbContext.Set<T>().Update(entity);
    }
}
