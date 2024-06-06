namespace TechnoShopApi.Inventory.Domain.Model.Commands;

public record UpdateProductCommand( string Name, string Description, decimal Price, int Quantity, string ImageUrl);