using MongoDB.Driver;
using IlayMor.Bookshelf.Services.Favorites.API.Models;

namespace IlayMor.Bookshelf.Services.Favorites.API.Data;

public class FavoritesRepo : IFavoritesRepo
{
    private readonly IMongoCollection<UserFavorites> _userFavoritesCollection;

    public FavoritesRepo(FavoritesDBSettings dBSettings)
    {
        var client = new MongoClient(dBSettings.ConnectionString);
        var database = client.GetDatabase(dBSettings.DatabaseName);
        _userFavoritesCollection = database.GetCollection<UserFavorites>(dBSettings.CollectionName);
    }

    public async Task<UserFavorites> GetUserFavoritesByIdAsync(Guid userId)
    {
        return await _userFavoritesCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task<UserFavorites> CreateUserFavoritesAsync(UserFavorites userFavorites)
    {
        try
        {
            await _userFavoritesCollection.InsertOneAsync(userFavorites);
            return userFavorites;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> DeleteUserFavoritesAsync(Guid userId)
    {
        try
        {
            await _userFavoritesCollection.DeleteOneAsync(x => x.UserId == userId);
            return true;
        }

        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<UserFavorites> UpdateUserFavoritesAsync(UserFavorites userFavorites)
    {
        try
        {
            await _userFavoritesCollection.ReplaceOneAsync(x => x.UserId == userFavorites.UserId, userFavorites);
            return userFavorites;
        }

        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<bool> UserFavoritesExists(Guid userId)
    {
        return await _userFavoritesCollection.Find(x => x.UserId == userId).AnyAsync();
    }

}