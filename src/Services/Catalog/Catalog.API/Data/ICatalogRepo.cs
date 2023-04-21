using IlayMor.Bookshelf.Services.Catalog.API.Models;

namespace IlayMor.Bookshelf.Services.Catalog.API.Data;

public interface ICatalogRepo
{
    Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync();
    Task<CatalogItem> GetCatalogItemByIdAsync(Guid id);
    Task AddCatalogItemAsync(CatalogItem catalogItem);
    Task UpdateCatalogItemAsync(CatalogItem catalogItem);
    Task DeleteCatalogItemAsync(Guid id);
    Task<bool> CatalogItemExists(Guid id);
}