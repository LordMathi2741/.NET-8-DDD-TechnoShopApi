using TechnoShopApi.Inventory.Domain.Model.Aggregates;

namespace TechnoShopApi.Inventory.Domain.Model.Commands;

public record CreateContainerCommand(string Name, int Capacity, long ProductId);