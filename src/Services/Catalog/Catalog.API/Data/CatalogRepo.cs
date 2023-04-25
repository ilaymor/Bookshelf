using IlayMor.Bookshelf.Services.Catalog.API.Models;
using MongoDB.Driver;

namespace IlayMor.Bookshelf.Services.Catalog.API.Data;

public class CatalogRepo : ICatalogRepo
{
    private readonly IMongoCollection<CatalogItem> _catalogItemsCollection;

    public CatalogRepo(CatalogDBSettings dBSettings)
    {
        var client = new MongoClient(dBSettings.ConnectionString);
        var database = client.GetDatabase(dBSettings.DatabaseName);
        _catalogItemsCollection = database.GetCollection<CatalogItem>(dBSettings.CollectionName);
    }

    public async Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync()
    {
        return await _catalogItemsCollection.Find(x => true).ToListAsync();
    }

    public async Task<CatalogItem> GetCatalogItemByIdAsync(Guid id)
    {
        return await _catalogItemsCollection.Find(x => x.ItemId == id).FirstOrDefaultAsync();
    }
    public async Task AddCatalogItemAsync(CatalogItem catalogItem)
    {
        if (catalogItem.ItemId == Guid.Empty)
        {
            catalogItem.ItemId = Guid.NewGuid();
        }

        await _catalogItemsCollection.InsertOneAsync(catalogItem);
    }
    public async Task UpdateCatalogItemAsync(CatalogItem catalogItem)
    {
        await _catalogItemsCollection.ReplaceOneAsync(x => x.ItemId == catalogItem.ItemId, catalogItem);
    }
    public async Task DeleteCatalogItemAsync(Guid id)
    {
        await _catalogItemsCollection.DeleteOneAsync(x => x.ItemId == id);
    }

    public async Task<bool> CatalogItemExists(Guid id)
    {
        return await _catalogItemsCollection.Find(x => x.ItemId == id).AnyAsync();
    }
}