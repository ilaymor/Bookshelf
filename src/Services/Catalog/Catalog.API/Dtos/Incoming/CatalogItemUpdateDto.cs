using System.ComponentModel.DataAnnotations;

namespace IlayMor.Bookshelf.Services.Catalog.API.Dtos;

public record CatalogItemUpdateDto(
    Guid ItemId,

    [Required]
    string Title,

    [Required]
    string Author);