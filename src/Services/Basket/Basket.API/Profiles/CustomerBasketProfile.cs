using IlayMor.Bookshelf.Services.Basket.API.Dtos;
using IlayMor.Bookshelf.Services.Basket.API.Models;
using AutoMapper;

namespace IlayMor.Bookshelf.Services.Basket.API.Profiles;

public class CustomerBasketProfile : Profile
{
    public CustomerBasketProfile()
    {
        CreateMap<CustomerBasket, CustomerBasketReadDto>();
        CreateMap<CustomerBasketUpdateDto, CustomerBasket>();
    }
}