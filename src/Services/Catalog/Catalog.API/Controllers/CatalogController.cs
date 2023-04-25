using Microsoft.AspNetCore.Mvc;
using IlayMor.Bookshelf.Services.Catalog.API.Data;
using IlayMor.Bookshelf.Services.Catalog.API.Models;
using IlayMor.Bookshelf.Services.Catalog.API.Dtos;
using IlayMor.Bookshelf.Services.Catalog.API.Profiles;
using IlayMor.Bookshelf.Services.Catalog.API.Messaging.Events;
using AutoMapper;
using MassTransit;

namespace IlayMor.Bookshelf.Services.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]/items")]
[Produces("application/json")]
public class CatalogController : ControllerBase
{
    private readonly ICatalogRepo _catalogRepo;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public CatalogController(ICatalogRepo catalogRepo, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _catalogRepo = catalogRepo;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CatalogItemReadDto>>> GetCatalogItems()
    {
        var catalogItems = await _catalogRepo.GetAllCatalogItemsAsync();
        var catalogItemReadDtos = _mapper.Map<IEnumerable<CatalogItemReadDto>>(catalogItems);
        return Ok(catalogItemReadDtos);
    }

    [HttpGet]
    [Route("{id:Guid}", Name = "GetCatalogItemByIdAsync")]
    public async Task<ActionResult<CatalogItemReadDto>> GetCatalogItemByIdAsync(Guid id)
    {
        var catalogItem = await _catalogRepo.GetCatalogItemByIdAsync(id);
        if (catalogItem == null)
        {
            return NotFound();
        }

        var catalogItemReadDto = _mapper.Map<CatalogItemReadDto>(catalogItem);

        return Ok(catalogItemReadDto);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCatalogItemAsync(CatalogItemCreateDto createDto)
    {
        var catalogItem = _mapper.Map<CatalogItem>(createDto);
        await _catalogRepo.AddCatalogItemAsync(catalogItem);
        return CreatedAtRoute(nameof(GetCatalogItemByIdAsync), new { id = catalogItem.ItemId }, null);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCatalogItemAsync(CatalogItemUpdateDto updateDto)
    {
        var catalogItem = await _catalogRepo.GetCatalogItemByIdAsync(updateDto.ItemId);
        if (catalogItem == null)
        {
            return NotFound();
        }

        _mapper.Map(updateDto, catalogItem);
        await _catalogRepo.UpdateCatalogItemAsync(catalogItem);

        return Ok();
    }


    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<ActionResult> DeleteCatalogItemAsync(Guid id)
    {
        var exists = await _catalogRepo.CatalogItemExists(id);
        if (!exists)
        {
            return NotFound();
        }

        await _catalogRepo.DeleteCatalogItemAsync(id);
        await _publishEndpoint.Publish<CatalogItemDeleted>(new {
            ItemId = id
        });

        return Ok();
    }
}
