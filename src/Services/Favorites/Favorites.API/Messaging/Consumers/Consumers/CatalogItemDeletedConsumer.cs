using MassTransit;
using IlayMor.Bookshelf.Services.Favorites.API.Data;
using IlayMor.Bookshelf.Commons.Events;
using IlayMor.Bookshelf.Services.Favorites.API.Models;

namespace IlayMor.Bookshelf.Services.Favorites.API.Messaging.Consumers;

class CatalogItemDeletedConsumer : IConsumer<CatalogItemDeleted>
{
    private readonly IFavoritesRepo _favoritesRepo;

    public CatalogItemDeletedConsumer(IFavoritesRepo favoritesRepo)
    {
        _favoritesRepo = favoritesRepo;
    }

    public async Task Consume(ConsumeContext<CatalogItemDeleted> context)
    {
        var deletedCatalogItemId = context.Message.Id;
        var usersFavorites = await _favoritesRepo.GetAllUsersFavoritesContainingItem(deletedCatalogItemId);
        foreach (UserFavorites userFavorites in usersFavorites)
        {
            await _favoritesRepo.RemoveItemFromUserFavorites(userFavorites, deletedCatalogItemId);
        }
    }
}