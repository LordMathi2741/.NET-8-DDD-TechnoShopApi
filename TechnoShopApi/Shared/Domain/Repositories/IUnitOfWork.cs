namespace TechnoShopApi.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}