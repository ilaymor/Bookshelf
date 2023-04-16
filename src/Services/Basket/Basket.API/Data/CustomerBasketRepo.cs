using IlayMor.Bookshelf.Services.Basket.API.Models;
using MongoDB.Driver;

namespace IlayMor.Bookshelf.Services.Basket.API.Data;

public class CustomerBasketRepo : ICustomerBasketRepo
{
    IMongoCollection<CustomerBasket> _customerBasketsCollection;

    public CustomerBasketRepo(CustomerBasketDBSettings dBSettings)
    {
        var client = new MongoClient(dBSettings.ConnectionString);
        var database = client.GetDatabase(dBSettings.DatabaseName);
       _customerBasketsCollection = database.GetCollection<CustomerBasket>(dBSettings.CollectionName);
    }

    public async Task<CustomerBasket> GetCustomerBasketByIdAsync(Guid customerId)
    {
        return await _customerBasketsCollection.Find(x => x.CustomerId == customerId).FirstOrDefaultAsync();
    }
    public async Task CreateCustomerBasketAsync(Guid customerId)
    {
        var customerBasket = new CustomerBasket(customerId);
        await _customerBasketsCollection.InsertOneAsync(customerBasket);
    }
    public async Task UpdateCustomerBasketAsync(CustomerBasket customerBasket)
    {
        await _customerBasketsCollection.ReplaceOneAsync(x => x.CustomerId == customerBasket.CustomerId, customerBasket);
    }
    public async Task DeleteCustomerBasketAsync(Guid customerId)
    {
        await _customerBasketsCollection.DeleteOneAsync(x => x.CustomerId == customerId);
    }
}