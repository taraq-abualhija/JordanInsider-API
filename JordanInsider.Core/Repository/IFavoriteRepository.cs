using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Repository
{
    public interface IFavoriteRepository
    {
        List<Favorite> GetAllFavorites();
        Favorite GetFavoriteById(decimal favoriteId);
        List<Favorite> GetFavoritesByUserId(decimal userId);
        List<Favorite> GetFavoritesByTouristSiteId(decimal touristSiteId);
        void CreateFavorite(Favorite favoriteData);
        void DeleteFavorite(decimal favoriteId);
        void DeleteFavoriteByUserAndTouristSite(decimal userId, decimal touristSiteId);
    }
}
