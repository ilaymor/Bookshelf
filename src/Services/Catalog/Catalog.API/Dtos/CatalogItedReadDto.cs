namespace IlayMor.Bookshelf.Services.Catalog.API.Dtos;

public record CatalogItemReadDto(
    Guid Id,
    string Title,
    string Author);