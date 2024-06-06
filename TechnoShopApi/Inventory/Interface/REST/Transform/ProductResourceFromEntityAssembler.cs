using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Interface.REST.Resources;

namespace TechnoShopApi.Inventory.Interface.REST.Transform;

public class ProductResourceFromEntityAssembler
{
   public static ProductResource ToResourceFromEntity(Product product)
   {
      return new ProductResource(product.Id, product.Name, product.Description, product.Price, product.Quantity, product.ImageUrl);
   }
}