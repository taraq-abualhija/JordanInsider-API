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
    public class HistoryRepository : IHistoryRepository
    {
        private readonly IDbContext dbContext;

        public HistoryRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<History> GetHistoryByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<History>("history_package.GetHistoryByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public History GetHistoryById(int historyId)
        {
            var p = new DynamicParameters();
            p.Add("p_historyId", historyId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<History>("history_package.GetHistoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateHistory(History historyData)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", historyData.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_touristSiteId", historyData.Touristsiteid, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("history_package.CreateHistory", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateHistory(History historyData)
        {
            var p = new DynamicParameters();
            p.Add("p_historyId", historyData.Historyid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_userId", historyData.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_touristSiteId", historyData.Touristsiteid, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("history_package.UpdateHistory", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteHistory(int historyId)
        {
            var p = new DynamicParameters();
            p.Add("p_historyId", historyId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("history_package.DeleteHistory", p, commandType: CommandType.StoredProcedure);
        }
    }
}
