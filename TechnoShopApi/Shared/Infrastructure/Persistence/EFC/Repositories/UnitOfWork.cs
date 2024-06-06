using TechnoShopApi.Shared.Domain.Repositories;
using TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}