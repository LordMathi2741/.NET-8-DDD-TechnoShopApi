namespace TechnoShopApi.Inventory.Domain.Model.Commands;

public record CreateProductCommand(string Name, string Description, decimal Price, int Quantity, string ImageUrl);