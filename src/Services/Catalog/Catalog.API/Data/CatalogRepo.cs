using IlayMor.Bookshelf.Services.Catalog.API.Models;
using MongoDB.Driver;

namespace IlayMor.Bookshelf.Services.Catalog.API.Data;

public class CatalogRepo : ICatalogRepo
{
    IMongoCollection<CatalogItem> _catalogItemsCollection;

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
        return await _catalogItemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
    public async Task AddCatalogItemAsync(CatalogItem catalogItem)
    {
        if (catalogItem.Id == Guid.Empty)
        {
            catalogItem.Id = Guid.NewGuid();
        }

        await _catalogItemsCollection.InsertOneAsync(catalogItem);
    }
    public async Task UpdateCatalogItemAsync(CatalogItem catalogItem)
    {
        await _catalogItemsCollection.ReplaceOneAsync(x => x.Id == catalogItem.Id, catalogItem);
    }
    public async Task DeleteCatalogItemAsync(Guid id)
    {
        await _catalogItemsCollection.DeleteOneAsync(x => x.Id == id);
    }
}