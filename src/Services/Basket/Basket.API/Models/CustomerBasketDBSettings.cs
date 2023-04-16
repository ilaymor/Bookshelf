namespace IlayMor.Bookshelf.Services.Basket.API.Models;

public record CustomerBasketDBSettings(
    string ConnectionString,
    string DatabaseName,
    string CollectionName);