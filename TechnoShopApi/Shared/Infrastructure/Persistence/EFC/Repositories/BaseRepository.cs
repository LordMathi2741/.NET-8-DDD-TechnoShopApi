using Microsoft.EntityFrameworkCore;
using TechnoShopApi.Shared.Domain.Repositories;
using TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public void UpdateAsync(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public void DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public async Task<TEntity?> FindByIdAsync(long id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync();
    }
}