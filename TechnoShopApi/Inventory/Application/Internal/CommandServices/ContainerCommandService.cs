using System.ComponentModel;
using TechnoShopApi.Inventory.Domain.Model.Aggregates;
using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Domain.Repositories;
using TechnoShopApi.Inventory.Domain.Services;
using TechnoShopApi.Shared.Domain.Repositories;

namespace TechnoShopApi.Inventory.Application.Internal.CommandServices;

public class ContainerCommandService(IContainerRepository containerRepository, IProductRepository productRepository,  IUnitOfWork unitOfWork ) :IContainerCommandService
{
    public async Task<ProductContainer?> Handle(CreateContainerCommand command)
    {
        var container = new ProductContainer(command);
        var productExisted = await productRepository.FindByIdAsync(command.ProductId);
        if (productExisted == null) return null;
        await containerRepository.AddAsync(container);
        await unitOfWork.CompleteAsync();
        return container;
    }
}