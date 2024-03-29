namespace api.Contracts;

public interface IBaseRepository<TEntity>
{
    ICollection<TEntity> GetAll();
    TEntity? GetByGuid(Guid guid);
    TEntity Create(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(TEntity entity);
    bool IsExist(Guid guid);
}
