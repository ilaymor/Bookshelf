namespace IlayMor.Bookshelf.Services.Basket.API.Models;

public class CustomerBasketItem
{
    public Guid CatalogItemId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }
}