namespace IlayMor.Bookshelf.Services.Catalog.API.Dtos;

public record CatalogItemReadDto(
    Guid ItemId,
    string Title,
    string Author);