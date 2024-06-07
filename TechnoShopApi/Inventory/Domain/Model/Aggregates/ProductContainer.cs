using TechnoShopApi.Inventory.Domain.Model.Commands;

namespace TechnoShopApi.Inventory.Domain.Model.Aggregates;

public partial class ProductContainer
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    
    public int CurrentCapacity { get; set; }
    
    public long ProductId { get; set; }
    public Product Product { get; set; }
}

public partial class ProductContainer
{
    public ProductContainer(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        CurrentCapacity = capacity - 1;
    }

    public ProductContainer(CreateContainerCommand command)
    {
        Name = command.Name;
        Capacity = command.Capacity;
        CurrentCapacity = command.Capacity;
        ProductId = command.ProductId;
    }
    
  
}