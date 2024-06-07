using System.ComponentModel;
using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Domain.Repositories;
using TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Configuration;
using TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TechnoShopApi.Inventory.Infrastructure.Persistence.EFC;

public class ContainerRepository(AppDbContext context) : BaseRepository<ProductContainer>(context), IContainerRepository
{
   
}
