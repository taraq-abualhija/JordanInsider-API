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
    public class EventRepository : IEventRepository
    {
        private readonly IDbContext dbContext;

        public EventRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Event> GetAllEvents()
        {
            IEnumerable<Event> result = dbContext.Connection.Query<Event>("Event_Package.GetAllEvents", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Event GetEventById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Event>("Event_Package_SPEC.GetEventById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateEvent(Event eventData)
        {
            var p = new DynamicParameters();
            p.Add("DATESTART", eventData.Datestart, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DETAILS", eventData.Details, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE1", eventData.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE2", eventData.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("VALIDITY", eventData.Validity, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Event_Package_SPEC.CreateEvent", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateEvent(Event eventData)
        {
            var p = new DynamicParameters();
            p.Add("ID", eventData.Eventid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("DATESTART", eventData.Datestart, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DETAILS", eventData.Details, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE1", eventData.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGE2", eventData.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("VALIDITY", eventData.Validity, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Event_Package_SPEC.UpdateEvent", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteEvent(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Event_Package_SPEC.DeleteEvent", p, commandType: CommandType.StoredProcedure);
        }
    }
}
