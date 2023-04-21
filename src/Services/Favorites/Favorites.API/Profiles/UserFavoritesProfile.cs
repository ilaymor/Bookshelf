using IlayMor.Bookshelf.Services.Favorites.API.Dtos;
using IlayMor.Bookshelf.Services.Favorites.API.Models;
using AutoMapper;

namespace IlayMor.Bookshelf.Services.Favorites.API.Profiles;

public class UserFavoritesProfile : Profile
{
    public UserFavoritesProfile()
    {
        CreateMap<UserFavorites, UserFavoritesReadDto>();
        CreateMap<UserFavoritesUpdateDto, UserFavorites>();
    }
}