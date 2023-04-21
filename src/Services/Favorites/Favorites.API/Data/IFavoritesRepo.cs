using IlayMor.Bookshelf.Services.Favorites.API.Models;

namespace IlayMor.Bookshelf.Services.Favorites.API.Data;

public interface IFavoritesRepo
{
    Task<UserFavorites> GetUserFavoritesByIdAsync(Guid userId);
    Task<UserFavorites> CreateUserFavoritesAsync(UserFavorites userFavorites);
    Task<bool> DeleteUserFavoritesAsync(Guid userId);
    Task<UserFavorites> UpdateUserFavoritesAsync(UserFavorites userFavorites);
    Task<bool> UserFavoritesExists(Guid userId);
}