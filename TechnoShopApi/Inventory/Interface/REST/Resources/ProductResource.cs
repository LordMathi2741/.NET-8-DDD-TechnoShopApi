namespace TechnoShopApi.Inventory.Interface.REST.Resources;

public record ProductResource(long Id, string Name, string Description, decimal Price, int Quantity, string ImageUrl);