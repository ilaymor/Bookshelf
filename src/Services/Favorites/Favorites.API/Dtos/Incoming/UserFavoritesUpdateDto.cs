using IlayMor.Bookshelf.Services.Favorites.API.Models;
using System.ComponentModel.DataAnnotations;

namespace IlayMor.Bookshelf.Services.Favorites.API.Dtos;

public record UserFavoritesUpdateDto(
    [Required]
    Guid UserId,

    [Required]
    IEnumerable<FavoriteItem> Favorites);