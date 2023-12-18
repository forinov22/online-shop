namespace OnlineShop.Exceptions;

public class OrderStatusException : Exception
{
    public OrderStatusException() { }

    public OrderStatusException(string message)
        : base(message) { }

    public OrderStatusException(string message, Exception inner)
        : base(message, inner) { } 
}
