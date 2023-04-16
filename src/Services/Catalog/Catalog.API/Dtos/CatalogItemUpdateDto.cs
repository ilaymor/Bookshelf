using System.ComponentModel.DataAnnotations;

namespace IlayMor.Bookshelf.Services.Catalog.API.Dtos;

public record CatalogItemUpdateDto(
    [Required]
    Guid Id,

    [Required]
    string Title,

    [Required]
    string Author);