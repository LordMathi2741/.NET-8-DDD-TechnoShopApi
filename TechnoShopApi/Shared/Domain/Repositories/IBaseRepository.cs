namespace TechnoShopApi.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    void UpdateAsync(TEntity entity);
    void DeleteAsync(TEntity entity);
    Task<TEntity?>FindByIdAsync(long id);
    Task<IEnumerable<TEntity>>FindAllAsync();
}