using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs;
using OnlineShop.Services;

namespace OnlineShop.Controllers;

[Route("api/addresses")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet("{addressId:int}")]
    public async Task<ActionResult<AddressDto>> GetAddress([FromRoute] int addressId)
    {
        var address = await _addressService.GetAddressByIdAsync(addressId);
        return address;
    }

    [HttpPost]
    public async Task<ActionResult<AddressDto>> CreateAddress([FromBody] AddressAdd dto)
    {
        var address = await _addressService.CreateAddressAsync(dto);
        return address;
    }
}