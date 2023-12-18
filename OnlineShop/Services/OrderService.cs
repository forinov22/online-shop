using Mapster;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using OnlineShop.Data;
using OnlineShop.Domains;
using OnlineShop.Exceptions;
using OnlineShop.Models.DTOs;
using OnlineShop.Models.Mappers;

namespace OnlineShop.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<IEnumerable<OrderDto>> GetAllUserOrdersAsync(int userId);
    Task<OrderDto> GetOrderByIdAsync(int orderId);
    Task<OrderDto> CreateOrderAsync(int userId);
    Task<OrderDto> UpdateOrderAsync(int orderId, OrderUpdate dto);
}

public class OrderService : IOrderService
{
    private readonly OnlineShopContext _context;
    private readonly ICartService _cartService;
    private readonly IAddressService _addressService;

    public OrderService(OnlineShopContext context, ICartService cartService, IAddressService addressService)
    {
        _context = context;
        _cartService = cartService;
        _addressService = addressService;
    }

    public async Task<OrderDto> CreateOrderAsync(int userId)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);
        if (address == null)
            throw new NotFoundException(ExceptionMessages.AddressNotFound);

        var cartItmes = await _cartService.GetUserCartAsync(userId);
        var price = cartItmes.Sum(ci => ci.ProductVersion.Product.Price * ci.Quantity);
        await _cartService.DeleteUserCartAsync(userId);
        
        var order = new Order { Price = price, UserId = userId, AddressId = address.Id, CreatedAt = DateTime.UtcNow, OrderStatus = OrderStatus.Processing };
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        var orderTransaction = new OrderTransaction { UpdatedAt = order.CreatedAt, OrderTransactionStatus = order.OrderStatus, OrderId = order.Id };
        var orderItems = cartItmes.Select(ci => new OrderItem { OrderId = order.Id, ProductVersionId = ci.ProductVersionId, Quantity = ci.Quantity } );
        order.OrderTransactions.Add(orderTransaction);
        order.OrderItems.AddRange(orderItems);
        await _context.SaveChangesAsync();
        var existringOrder = await _context.Orders.ProjectToType<OrderDto>()
            .FirstAsync(o => o.Id == order.Id);
        return existringOrder;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        return await _context.Orders.ProjectToType<OrderDto>().ToListAsync();
    }

    public async Task<IEnumerable<OrderDto>> GetAllUserOrdersAsync(int userId)
    {
        return await _context.Orders.ProjectToType<OrderDto>()
            .Where(o => o.UserId == userId).ToListAsync();
    }

    public async Task<OrderDto> GetOrderByIdAsync(int orderId)
    {
        var order = await _context.Orders.ProjectToType<OrderDto>()
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (order == null)
            throw new NotFoundException(ExceptionMessages.OrderNotFound);

        return order;
    }

    public async Task<OrderDto> UpdateOrderAsync(int orderId, OrderUpdate dto)
    {
        var existringOrder = await _context.Orders.FindAsync(orderId);

        if (existringOrder == null)
            throw new NotFoundException(ExceptionMessages.OrderNotFound);

        if (!Enum.TryParse<OrderStatus>(dto.OrderStatus, out var status))
            throw new OrderStatusException(ExceptionMessages.WrongOrderStatus);

        var orderTransaction = new OrderTransaction { OrderId = orderId, UpdatedAt = DateTime.UtcNow, OrderTransactionStatus = status };
        existringOrder.OrderTransactions.Add(orderTransaction);
        existringOrder.OrderStatus = status;

        await _context.SaveChangesAsync();
        return existringOrder.AdaptToDto();
    }
}
