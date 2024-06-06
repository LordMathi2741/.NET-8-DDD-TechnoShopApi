using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Domain.Model.Queries;
using TechnoShopApi.Inventory.Domain.Repositories;
using TechnoShopApi.Inventory.Domain.Services;

namespace TechnoShopApi.Inventory.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository repository) : IProductQueryService
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await repository.FindAllAsync();
    }

    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await repository.FindByIdAsync(query.Id);
    }
}