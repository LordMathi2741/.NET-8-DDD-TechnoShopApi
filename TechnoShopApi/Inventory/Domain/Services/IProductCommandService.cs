using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Domain.Model.Commands;

namespace TechnoShopApi.Inventory.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
    Task<Product?> Handle(long id, UpdateProductCommand command);
    Task<Product?> Handle(DeleteProductCommand command);
}