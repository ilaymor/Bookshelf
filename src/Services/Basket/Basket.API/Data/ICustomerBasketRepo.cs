using IlayMor.Bookshelf.Services.Basket.API.Models;

namespace IlayMor.Bookshelf.Services.Basket.API.Data;

public interface ICustomerBasketRepo
{
    Task<CustomerBasket> GetCustomerBasketByIdAsync(Guid customerId);
    Task CreateCustomerBasketAsync(Guid customerId);
    Task UpdateCustomerBasketAsync(CustomerBasket customerBasket);
    Task DeleteCustomerBasketAsync(Guid customerId);
}