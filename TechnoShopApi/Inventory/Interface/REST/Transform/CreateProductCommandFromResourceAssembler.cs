using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Interface.REST.Resources;

namespace TechnoShopApi.Inventory.Interface.REST.Transform;

public class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource (CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Name, resource.Description, resource.Price, resource.Quantity, resource.ImageUrl);
    }
}