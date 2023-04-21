using IlayMor.Bookshelf.Services.Favorites.API.Models;

namespace IlayMor.Bookshelf.Services.Favorites.API.Dtos;

public record UserFavoritesReadDto(
    Guid UserId,
    IEnumerable<FavoriteItem> Favorites);
