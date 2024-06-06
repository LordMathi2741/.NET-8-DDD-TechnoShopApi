using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Domain.Repositories;
using TechnoShopApi.Inventory.Domain.Services;
using TechnoShopApi.Shared.Domain.Exceptions;
using TechnoShopApi.Shared.Domain.Repositories;

namespace TechnoShopApi.Inventory.Application.Internal.CommandServices;

public class ProductCommandService(IUnitOfWork unitOfWork, IProductRepository productRepository) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var product = new Product(command);
        if (command.Price <= 0)
        {
            throw new InvalidProductPriceException("Price must be greater than 0");
        }
        if (command.Quantity <= 0)
        {
            throw new InvalidProductQuantityException("Quantity must be greater than 0");
        }

        if (command.Name.Length < 3)
        {
            throw new InvalidProductNameException("Name must be at least 3 characters long");
        }
        await productRepository.AddAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<Product?> Handle(long id,UpdateProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(id);
        if (product == null) return null;
        productRepository.UpdateAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }
    

    public async Task<Product?> Handle(DeleteProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.Id);
        if (product == null) return null;
        productRepository.DeleteAsync(product);
        await unitOfWork.CompleteAsync();
        return product;
    }
}