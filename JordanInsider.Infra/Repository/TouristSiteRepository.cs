using Dapper;
using JordanInsider.Core.Common;
using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Infra.Repository
{
    public class TouristSiteRepository : ITouristSiteRepository
    {
        private readonly IDbContext dbContext;

        public TouristSiteRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Touristsite> GetAllTouristSites()
        {
            IEnumerable<Touristsite> result = dbContext.Connection.Query<Touristsite>("touristsite_package.GetAllTouristSites", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Touristsite GetTouristSiteById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("touristSiteId1", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Touristsite>("TouristSite_Package.GetTouristSiteById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateTouristSite(Touristsite touristSiteData)
        {
            var p = new DynamicParameters();
            p.Add("NAME", touristSiteData.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_coordinatorId", touristSiteData.Coordinatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            p.Add("DESCRIPTION", touristSiteData.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE1", touristSiteData.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE2", touristSiteData.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE3", touristSiteData.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE4", touristSiteData.Image4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("status", touristSiteData.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("location", touristSiteData.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("tfrom", touristSiteData.Tfrom, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("tto", touristSiteData.Tto, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("TouristSite_Package.CreateTouristSite", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTouristSite(Touristsite touristSiteData)
        {
            var p = new DynamicParameters();
            p.Add("p_touristSiteId", touristSiteData.Touristsiteid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_coordinatorId", touristSiteData.Coordinatorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("p_name", touristSiteData.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_description", touristSiteData.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image1", touristSiteData.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image2", touristSiteData.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image3", touristSiteData.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image4", touristSiteData.Image4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_status", touristSiteData.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_location", touristSiteData.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_tfrom", touristSiteData.Tfrom, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_tto", touristSiteData.Tto, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("TouristSite_Package.UpdateTouristSite", p, commandType: CommandType.StoredProcedure);
        }


        public void DeleteTouristSite(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("touristSiteId1", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("TouristSite_Package.DeleteTouristSite", p, commandType: CommandType.StoredProcedure);
        }
        public void AcceptTouristSite(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("touristSiteId1", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("TouristSite_Package.AcceptTouristSite", p, commandType: CommandType.StoredProcedure);
        }
        public List<Touristsite> SearchTouristSiteByName(string name)
        {
            var p = new DynamicParameters();
            p.Add("search_name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Touristsite>("TouristSite_Package.SearchTouristSiteByName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
