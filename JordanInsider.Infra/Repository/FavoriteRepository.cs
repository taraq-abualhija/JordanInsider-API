using Dapper;
using JordanInsider.Core.Common;
using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JordanInsider.Infra.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly IDbContext dbContext;

        public FavoriteRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Favorite> GetAllFavorites()
        {
            IEnumerable<Favorite> result = dbContext.Connection.Query<Favorite>("favorite_package.GetAllFavorites", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Favorite GetFavoriteById(decimal favoriteId)
        {
            var p = new DynamicParameters();
            p.Add("p_favoriteId", favoriteId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Favorite>("favorite_package.GetFavoriteById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Favorite> GetFavoritesByUserId(decimal userId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Favorite>("favorite_package.GetFavoritesByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Favorite> GetFavoritesByTouristSiteId(decimal touristSiteId)
        {
            var p = new DynamicParameters();
            p.Add("p_touristSiteId", touristSiteId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Favorite>("favorite_package.GetFavoritesByTouristSiteId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateFavorite(Favorite favoriteData)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", favoriteData.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_touristSiteId", favoriteData.Touristsiteid, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("favorite_package.CreateFavorite", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteFavorite(decimal favoriteId)
        {
            var p = new DynamicParameters();
            p.Add("p_favoriteId", favoriteId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("favorite_package.DeleteFavorite", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteFavoriteByUserAndTouristSite(decimal userId, decimal touristSiteId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_touristSiteId", touristSiteId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("favorite_package.DeleteFavoriteByUserAndTouristSite", p, commandType: CommandType.StoredProcedure);
        }
    }
}
