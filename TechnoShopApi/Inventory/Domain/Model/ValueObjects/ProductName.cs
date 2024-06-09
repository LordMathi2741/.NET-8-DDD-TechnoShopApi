namespace TechnoShopApi.Inventory.Domain.Model.ValueObjects;

public record ProductName(string Name)
{
    public ProductName() : this(string.Empty)
    {
        
    }
}