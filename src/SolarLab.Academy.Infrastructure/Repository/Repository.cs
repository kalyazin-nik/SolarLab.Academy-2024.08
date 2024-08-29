using SolarLab.Academy.Domain.Base;

namespace SolarLab.Academy.Infrastructure.Repository;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    public void Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> GetByPredicate(Predicate<TEntity> predicate)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
