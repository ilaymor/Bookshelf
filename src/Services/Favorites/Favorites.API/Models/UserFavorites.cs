namespace IlayMor.Bookshelf.Services.Favorites.API.Models;

public class UserFavorites
{
    public Guid UserId { get; set; }
    public IEnumerable<FavoriteItem> Favorites { get; set; }

    public UserFavorites(Guid userId)
    {
        UserId = userId;
        Favorites = new List<FavoriteItem>();
    }
}
