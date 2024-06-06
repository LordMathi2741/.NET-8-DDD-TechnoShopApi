using TechnoShopApi.Inventory.Domain.Model.Commands;

namespace TechnoShopApi.Inventory.Domain.Model.Aggregates;

public partial class Product
{
    public long Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
}

public partial class Product
{
    public Product(string name, string description, decimal price, int quantity, string imageUrl)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        ImageUrl = imageUrl;
    }

    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Price = command.Price;
        Quantity = command.Quantity;
        ImageUrl = command.ImageUrl;
    }
}