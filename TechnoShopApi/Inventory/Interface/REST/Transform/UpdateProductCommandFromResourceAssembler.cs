using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Interface.REST.Resources;

namespace TechnoShopApi.Inventory.Interface.REST.Transform;

public class UpdateProductCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(UpdateProductResource resource)
    {
        return new UpdateProductCommand(resource.Name, resource.Description, resource.Price, resource.Quantity, resource.ImageUrl);
    }
}