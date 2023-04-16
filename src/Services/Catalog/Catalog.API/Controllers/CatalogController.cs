using Microsoft.AspNetCore.Mvc;
using IlayMor.Bookshelf.Services.Catalog.API.Data;
using IlayMor.Bookshelf.Services.Catalog.API.Models;
using IlayMor.Bookshelf.Services.Catalog.API.Dtos;
using IlayMor.Bookshelf.Services.Catalog.API.Profiles;
using AutoMapper;

namespace IlayMor.Bookshelf.Services.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CatalogController : ControllerBase
{
    private readonly ICatalogRepo _catalogRepo;
    private readonly IMapper _mapper;

    public CatalogController(ICatalogRepo catalogRepo, IMapper mapper)
    {
        _catalogRepo = catalogRepo;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("items")]
    public async Task<ActionResult<IEnumerable<CatalogItemReadDto>>> GetCatalogItems()
    {
        var catalogItems = await _catalogRepo.GetAllCatalogItemsAsync();
        var catalogItemReadDtos = _mapper.Map<IEnumerable<CatalogItemReadDto>>(catalogItems);
        return Ok(catalogItemReadDtos);
    }

    [HttpGet]
    [Route("items/{id:Guid}", Name = "GetCatalogItemByIdAsync")]
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
    [Route("items")]
    public async Task<ActionResult> CreateCatalogItemAsync(CatalogItemCreateDto createDto)
    {
        var catalogItem = _mapper.Map<CatalogItem>(createDto);
        await _catalogRepo.AddCatalogItemAsync(catalogItem);
        return CreatedAtRoute(nameof(GetCatalogItemByIdAsync), new { id = catalogItemReadDto.Id }, null);
    }

    [HttpPut]
    [Route("items")]
    public async Task<ActionResult> UpdateCatalogItemAsync(CatalogItemUpdateDto updateDto)
    {
        var catalogItem = await _catalogRepo.GetCatalogItemByIdAsync(updateDto.Id);
        if (catalogItem == null)
        {
            return NotFound();
        }

        _mapper.Map(updateDto, catalogItem);
        await _catalogRepo.UpdateCatalogItemAsync(catalogItem);

        return Ok();
    }

    [HttpDelete]
    [Route("items/{id:Guid}")]
    public async Task<ActionResult> DeleteCatalogItemAsync(Guid id)
    {
        var catalogItem = await _catalogRepo.GetCatalogItemByIdAsync(id);
        if (catalogItem == null)
        {
            return NotFound();
        }

        await _catalogRepo.DeleteCatalogItemAsync(id);
        return Ok();
    }
}
