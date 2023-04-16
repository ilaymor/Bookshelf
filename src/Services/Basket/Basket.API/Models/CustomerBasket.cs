namespace IlayMor.Bookshelf.Services.Basket.API.Models;

public class CustomerBasket
{
    public Guid CustomerId { get; set; }
    public List<CustomerBasketItem> Items { get; set; } = new();

    public CustomerBasket(Guid customerId)
    {
        CustomerId = customerId;
    }
}