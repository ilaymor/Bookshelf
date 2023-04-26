namespace IlayMor.Bookshelf.Services.Catalog.API.Models;

public record CatalogDBSettings(
    string ConnectionString,
    string DatabaseName,
    string CollectionName);