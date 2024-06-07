
using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Domain.Model.Commands;

namespace TechnoShopApi.Inventory.Domain.Services;

public interface IContainerCommandService
{
    Task<ProductContainer?> Handle(CreateContainerCommand command);
}