namespace TechnoShopApi.Inventory.Interface.REST.Resources;

public record CreateContainerResource(string Name, int Capacity, long ProductId);