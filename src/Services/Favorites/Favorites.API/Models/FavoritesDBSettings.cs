namespace IlayMor.Bookshelf.Services.Favorites.API.Models;

public record FavoritesDBSettings(
    string ConnectionString,
    string DatabaseName,
    string CollectionName);