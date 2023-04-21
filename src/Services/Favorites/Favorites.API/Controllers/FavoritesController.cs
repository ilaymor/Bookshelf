using Microsoft.AspNetCore.Mvc;
using IlayMor.Bookshelf.Services.Favorites.API.Data;
using IlayMor.Bookshelf.Services.Favorites.API.Dtos;
using IlayMor.Bookshelf.Services.Favorites.API.Models;
using AutoMapper;

namespace Favorites.API.Controllers;

[ApiController]
[Route("api/[controller]/userfavorites")]
public class FavoritesController : ControllerBase
{
    private readonly IFavoritesRepo _favoritesRepo;
    private readonly IMapper _mapper;

    public FavoritesController(IFavoritesRepo favoritesRepo, IMapper mapper)
    {
        _favoritesRepo = favoritesRepo;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{userId:Guid}")]
    public async Task<ActionResult<UserFavoritesReadDto>> GetUserFavoritesAsync(Guid userId)
    {
        var userFavorites = await _favoritesRepo.GetUserFavoritesByIdAsync(userId);
        if (userFavorites == null)
        {
            return NotFound();
        }

        var userFavoritesReadDto = _mapper.Map<UserFavoritesReadDto>(userFavorites);
        return Ok(userFavoritesReadDto);
    }

    [HttpPost]
    [Route("{userId:Guid}")]
    public async Task<ActionResult<UserFavoritesReadDto>> CreateUserFavoritesAsync(Guid userId)
    {
        var exists = await _favoritesRepo.UserFavoritesExists(userId);
        if (exists)
        {
            return Conflict();
        }

        UserFavorites userFavorites = new(userId);
        var createdUserFavorites = await _favoritesRepo.CreateUserFavoritesAsync(userFavorites);
        var createdUserFavoritesReadDto = _mapper.Map<UserFavoritesReadDto>(createdUserFavorites);
        return CreatedAtRoute(nameof(GetUserFavoritesAsync), new { userId = userId}, createdUserFavoritesReadDto);
    }

    [HttpPut]
    public async Task<ActionResult<UserFavoritesReadDto>> UpdateUserFavoritesAsync(UserFavoritesUpdateDto updateDto)
    {
        var userFavorites = await _favoritesRepo.GetUserFavoritesByIdAsync(updateDto.UserId);
        if (userFavorites == null)
        {
            return NotFound();
        }

        _mapper.Map(updateDto, userFavorites);
        var updatedUserFavorites = await _favoritesRepo.UpdateUserFavoritesAsync(userFavorites);
        var updatedUserFavoritesReadDto = _mapper.Map<UserFavoritesReadDto>(updatedUserFavorites);
        return Ok(updatedUserFavoritesReadDto);
    }

    [HttpDelete]
    [Route("{userId:Guid}")]
    public async Task<ActionResult> DeleteUserFavoritesAsync(Guid userId)
    {
        var exists = await _favoritesRepo.UserFavoritesExists(userId);
        if (!exists)
        {
            return NotFound();
        }

        var deleted = await _favoritesRepo.DeleteUserFavoritesAsync(userId);
        if (!deleted)
        {
            return BadRequest();
        }

        return Ok();
    }
}
