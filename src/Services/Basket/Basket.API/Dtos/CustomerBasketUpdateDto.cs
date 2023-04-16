using System.ComponentModel.DataAnnotations;
using IlayMor.Bookshelf.Services.Basket.API.Models;

namespace IlayMor.Bookshelf.Services.Basket.API.Dtos;

public record CustomerBasketUpdateDto(
    [Required]
    Guid CustomerId,

    [Required]
    List<CustomerBasketItem> Items);