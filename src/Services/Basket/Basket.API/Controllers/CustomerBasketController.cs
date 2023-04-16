using Microsoft.AspNetCore.Mvc;
using IlayMor.Bookshelf.Services.Basket.API.Data;
using IlayMor.Bookshelf.Services.Basket.API.Dtos;
using IlayMor.Bookshelf.Services.Basket.API.Models;
using AutoMapper;

namespace IlayMor.Bookshelf.Services.Basket.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]

public class CustomerBasketController : ControllerBase
{

    private readonly ICustomerBasketRepo _customerBasketRepo;
    private readonly IMapper _mapper;

    public CustomerBasketController(ICustomerBasketRepo customerBasketRepo, IMapper mapper)
    {
        _customerBasketRepo = customerBasketRepo;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("CustomerBaskets/{id:Guid}", Name = "GetCustomerBasketByIdAsync")]
    public async Task<ActionResult<CustomerBasketReadDto>> GetCustomerBasketByIdAsync(Guid id)
    {
        var customerBasket = await _customerBasketRepo.GetCustomerBasketByIdAsync(id);
        if (customerBasket == null)
        {
            return NotFound();
        }

        var customerBasketReadDto = _mapper.Map<CustomerBasketReadDto>(customerBasket);
        return Ok(customerBasketReadDto);
    }

    [HttpPost]
    [Route("CustomerBaskets/{id:Guid}")]
    public async Task<ActionResult> CreateCustomerBasketAsync(Guid id)
    {
        var catalogItem = _customerBasketRepo.GetCustomerBasketByIdAsync(id);
        if (catalogItem != null)
        {
            return new StatusCodeResult(409);
        }

        await _customerBasketRepo.CreateCustomerBasketAsync(id);

        return CreatedAtRoute(nameof(GetCustomerBasketByIdAsync), new { id = id }, null);
    }

    [HttpPut]
    [Route("CustomerBaskets")]
    public async Task<ActionResult> UpdateCustomerBasketAsync(CustomerBasketUpdateDto updateDto)
    {
        var catalogItem = _customerBasketRepo.GetCustomerBasketByIdAsync(updateDto.CustomerId);
        if (catalogItem == null)
        {
            return NotFound();
        }

        var customerBasket = _mapper.Map<CustomerBasket>(updateDto);
        await _customerBasketRepo.UpdateCustomerBasketAsync(customerBasket);

        return Ok();
    }

    [HttpDelete]
    [Route("CustomerBaskets/{id:Guid}")]
    public async Task<ActionResult> DeleteCustomerBasketAsync(Guid id)
    {
        var customerBasket = _customerBasketRepo.GetCustomerBasketByIdAsync(id);
        if (customerBasket == null)
        {
            return NotFound();
        }

        await _customerBasketRepo.DeleteCustomerBasketAsync(id);

        return Ok();
    }
}
