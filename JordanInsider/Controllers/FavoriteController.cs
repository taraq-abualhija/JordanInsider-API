using JordanInsider.Core.Models;
using JordanInsider.Core.Service;
using JordanInsider.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JordanInsider.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [HttpGet]
        [Route("GetAllFavorites")]
        public IActionResult GetAllFavorites()
        {
            try
            {
                var favorites = favoriteService.GetAllFavorites();
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving favorites: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetFavoriteById/{id}")]
        public IActionResult GetFavoriteById(decimal id)
        {
            try
            {
                var favorite = favoriteService.GetFavoriteById(id);
                if (favorite == null)
                    return NotFound();

                return Ok(favorite);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the favorite: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetFavoritesByUserId/{userId}")]
        public IActionResult GetFavoritesByUserId(decimal userId)
        {
            try
            {
                var favorites = favoriteService.GetFavoritesByUserId(userId);
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving favorites: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetFavoritesByTouristSiteId/{touristSiteId}")]
        public IActionResult GetFavoritesByTouristSiteId(decimal touristSiteId)
        {
            try
            {
                var favorites = favoriteService.GetFavoritesByTouristSiteId(touristSiteId);
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving favorites: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateFavorite")]
        public IActionResult CreateFavorite(Favorite favoriteData)
        {
            try
            {
                favoriteService.CreateFavorite(favoriteData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the favorite: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteFavorite/{id}")]
        public IActionResult DeleteFavorite(decimal id)
        {
            try
            {
                favoriteService.DeleteFavorite(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the favorite: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteFavoriteByUserAndTouristSite/{userId}/{touristSiteId}")]
        public IActionResult DeleteFavoriteByUserAndTouristSite(decimal userId, decimal touristSiteId)
        {
            try
            {
                favoriteService.DeleteFavoriteByUserAndTouristSite(userId, touristSiteId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the favorite: " + ex.Message);
            }
        }
    }
}
