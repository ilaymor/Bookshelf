using System.ComponentModel.DataAnnotations;

namespace IlayMor.Bookshelf.Services.Catalog.API.Dtos;

public record CatalogItemCreateDto(
    [Required]
    string Title,

    [Required]
    string Author);