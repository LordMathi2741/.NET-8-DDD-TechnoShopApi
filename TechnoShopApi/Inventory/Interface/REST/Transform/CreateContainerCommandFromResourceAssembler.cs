using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Interface.REST.Resources;

namespace TechnoShopApi.Inventory.Interface.REST.Transform;

public class CreateContainerCommandFromResourceAssembler
{
    public static CreateContainerCommand ToCommandFromResource(CreateContainerResource resource)
    {
        return new CreateContainerCommand(resource.Name, resource.Capacity, resource.ProductId);
    }
}