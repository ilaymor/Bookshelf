using IlayMor.Bookshelf.Services.Catalog.API.Dtos;
using IlayMor.Bookshelf.Services.Catalog.API.Models;
using AutoMapper;

namespace IlayMor.Bookshelf.Services.Catalog.API.Profiles;

public class CatalogItemProfile : Profile
{
    public CatalogItemProfile()
    {
        CreateMap<CatalogItem, CatalogItemReadDto>();
        CreateMap<CatalogItemUpdateDto, CatalogItem>();
        CreateMap<CatalogItemCreateDto, CatalogItem>();
    }
}