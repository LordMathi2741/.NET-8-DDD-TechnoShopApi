namespace TechnoShopApi.Inventory.Interface.REST.Resources;

public record ContainerResource(long Id, string Name, int Capacity, int CurrentCapacity, long ProductId);