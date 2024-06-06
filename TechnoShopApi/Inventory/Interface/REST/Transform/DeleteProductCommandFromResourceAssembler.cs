using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Interface.REST.Resources;

namespace TechnoShopApi.Inventory.Interface.REST.Transform;

public class DeleteProductCommandFromResourceAssembler
{
    public static DeleteProductCommand ToCommandFromResource(DeleteProductResource resource)
    {
        return new DeleteProductCommand(resource.Id);
    }
}