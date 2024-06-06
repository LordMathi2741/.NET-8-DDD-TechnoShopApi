namespace TechnoShopApi.Shared.Domain.Exceptions;

public class InvalidProductPriceException : Exception
{
    public InvalidProductPriceException(string message) : base(message)
    {
    }
    public InvalidProductPriceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}