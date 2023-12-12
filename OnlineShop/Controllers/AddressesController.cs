using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.DTOs.OnlineShop.Domains;
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

        if (address == null)
            return NotFound();
        
        return Ok(address);
    }

    [HttpPost]
    public async Task<ActionResult<AddressDto>> CreateAddress([FromBody] AddressAdd dto)
    {
        var address = await _addressService.CreateAddressAsync(dto);
        return Ok(address);
    }
}