namespace TechnoShopApi.Shared.Domain.Exceptions;

public class InvalidProductNameException : Exception
{
    public InvalidProductNameException(string message) : base(message)
    {
    }
    
    public InvalidProductNameException(string message, Exception innerException) : base(message, innerException)
    {
    }
}