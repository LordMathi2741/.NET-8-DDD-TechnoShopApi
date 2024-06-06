namespace TechnoShopApi.Shared.Domain.Exceptions;

public class InvalidProductQuantityException : Exception
{
    public InvalidProductQuantityException(string message) : base(message)
    {
    }
    
    public InvalidProductQuantityException(string message, Exception innerException) : base(message, innerException)
    {
    }
}