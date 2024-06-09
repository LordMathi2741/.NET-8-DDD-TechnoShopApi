using System.ComponentModel;
using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Domain.Model.ValueObjects;

namespace TechnoShopApi.Inventory.Domain.Model.Aggregates;

public partial class Product
{
    
    public ProductName ProductName { get; private set; }
    public ProductDescription ProductDescriptionValue { get; private set; }
    
    public ICollection<ProductContainer> Containers { get; set; }
}


public partial class Product
{
    public long Id { get; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }

    public string Name => ProductName.Name;
    public string Description => ProductDescriptionValue.Description;

}

public partial class Product
{

    /// <summary>
    ///  Default constructor for EF
    /// </summary>
    public Product()
    {
        ProductName = new ProductName();
        ProductDescriptionValue = new ProductDescription();
    }
    
    public Product(string name, string description, decimal price, int quantity, string imageUrl)
    {
        ProductName = new ProductName(name);
        ProductDescriptionValue = new ProductDescription(description);
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
    }

    public Product(CreateProductCommand command)
    {
        ProductName = new ProductName(command.Name);
        ProductDescriptionValue = new ProductDescription(command.Description);
        Price = command.Price;
        Quantity = command.Quantity;
        ImageUrl = command.ImageUrl;
    }
}