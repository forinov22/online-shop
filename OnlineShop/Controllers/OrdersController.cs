using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;
using System.Security.Claims;

namespace OnlineShop.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return orders.ToList();
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{orderId:int}")]
    public async Task<ActionResult<OrderDto>> GetOrder([FromRoute] int orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        return order == null ? NotFound() : order;
    }

    [Authorize(Roles = "User")]
    [HttpGet("user")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllUserOrders()
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var orders = await _orderService.GetAllUserOrdersAsync(userId);
        return orders.ToList();
    }

    [Authorize(Roles = "User")]
    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder()
    {
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            return Forbid();

        var order = await _orderService.CreateOrderAsync(userId);
        return order;
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{orderId:int}")]
    public async Task<ActionResult<OrderDto>> UpdateOrder([FromRoute] int orderId, [FromBody] OrderUpdate dto)
    {
        var order = await _orderService.UpdateOrderAsync(orderId, dto);
        return order == null ? NotFound() : order;
    }
}
