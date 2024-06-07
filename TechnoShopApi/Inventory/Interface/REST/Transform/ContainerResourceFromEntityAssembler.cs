using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Interface.REST.Resources;

namespace TechnoShopApi.Inventory.Interface.REST.Transform;

public class ContainerResourceFromEntityAssembler
{
    public static ContainerResource ToResourceFromEntity(ProductContainer entity)
    {
        return new ContainerResource(entity.Id, entity.Name, entity.Capacity, entity.CurrentCapacity, entity.ProductId);
    }
}