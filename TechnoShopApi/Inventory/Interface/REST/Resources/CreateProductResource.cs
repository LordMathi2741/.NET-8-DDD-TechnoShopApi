using TechnoShopApi.Inventory.Domain.Model.Aggregates;

namespace TechnoShopApi.Inventory.Interface.REST.Resources;

public record CreateProductResource(string Name, string Description, decimal Price, int Quantity, string ImageUrl);