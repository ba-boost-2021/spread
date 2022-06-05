namespace Spread.Data.Abstractions;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : EntityBase;
    int SaveChanges();
}