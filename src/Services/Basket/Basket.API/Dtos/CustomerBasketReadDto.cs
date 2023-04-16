using IlayMor.Bookshelf.Services.Basket.API.Models;

namespace IlayMor.Bookshelf.Services.Basket.API.Dtos;

public record CustomerBasketReadDto(
    Guid CustomerId,
    List<CustomerBasketItem> Items);