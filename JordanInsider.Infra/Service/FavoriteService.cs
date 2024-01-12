using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using JordanInsider.Core.Service;
using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository favoriteRepository;

        public FavoriteService(IFavoriteRepository _favoriteRepository)
        {
            this.favoriteRepository = _favoriteRepository;
        }

        public List<Favorite> GetAllFavorites()
        {
            return favoriteRepository.GetAllFavorites();
        }

        public Favorite GetFavoriteById(decimal favoriteId)
        {
            return favoriteRepository.GetFavoriteById(favoriteId);
        }

        public List<Favorite> GetFavoritesByUserId(decimal userId)
        {
            return favoriteRepository.GetFavoritesByUserId(userId);
        }

        public List<Favorite> GetFavoritesByTouristSiteId(decimal touristSiteId)
        {
            return favoriteRepository.GetFavoritesByTouristSiteId(touristSiteId);
        }

        public void CreateFavorite(Favorite favoriteData)
        {
            favoriteRepository.CreateFavorite(favoriteData);
        }

        public void DeleteFavorite(decimal favoriteId)
        {
            favoriteRepository.DeleteFavorite(favoriteId);
        }

        public void DeleteFavoriteByUserAndTouristSite(decimal userId, decimal touristSiteId)
        {
            favoriteRepository.DeleteFavoriteByUserAndTouristSite(userId, touristSiteId);
        }
    }
}
