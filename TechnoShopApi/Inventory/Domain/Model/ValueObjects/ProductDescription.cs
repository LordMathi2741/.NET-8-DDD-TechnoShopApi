namespace TechnoShopApi.Inventory.Domain.Model.ValueObjects;

public record ProductDescription(string Description)
{
    public ProductDescription() : this(string.Empty)
    {

    }

}