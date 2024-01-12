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
            IEnumerable<Event> result = dbContext.Connection.Query<Event>("event_package.GetAllEvents", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Event GetEventById(decimal eventId)
        {
            var p = new DynamicParameters();
            p.Add("p_eventId", eventId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Event>("event_package.GetEventById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateEvent(Event eventData)
        {
            var p = new DynamicParameters();
            p.Add("name", eventData.Name, DbType.String, ParameterDirection.Input);
           p.Add("p_coordinatorId", eventData.Coordinatoorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            p.Add("start_date", eventData.Datestart, DbType.String, ParameterDirection.Input);
            p.Add("event_details", eventData.Details, DbType.String, ParameterDirection.Input);
            p.Add("img1", eventData.Image1, DbType.String, ParameterDirection.Input);
            p.Add("img2", eventData.Image2, DbType.String, ParameterDirection.Input);
            p.Add("location", eventData.Location, DbType.String, ParameterDirection.Input);

            p.Add("valid_until", eventData.Validity, DbType.String, ParameterDirection.Input);
            p.Add("p_price", eventData.Price, DbType.Decimal, ParameterDirection.Input);

            var result = dbContext.Connection.Execute("event_package.CreateEvent", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateEvent(Event eventData)
        {
            var p = new DynamicParameters();
            p.Add("p_eId", eventData.Eventid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_coordinatorId", eventData.Coordinatoorid, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            p.Add("p_name", eventData.Name, DbType.String, ParameterDirection.Input);
            p.Add("p_location", eventData.Location, DbType.String, ParameterDirection.Input);

            p.Add("p_start_date", eventData.Datestart, DbType.String, ParameterDirection.Input);
            p.Add("p_event_details", eventData.Details, DbType.String, ParameterDirection.Input);
            p.Add("p_img1", eventData.Image1, DbType.String, ParameterDirection.Input);
            p.Add("p_img2", eventData.Image2, DbType.String, ParameterDirection.Input);
            p.Add("p_valid_until", eventData.Validity, DbType.String, ParameterDirection.Input);
            p.Add("p_price", eventData.Price, DbType.Decimal, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("event_package.UpdateEvent", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteEvent(decimal eventId)
        {
            var p = new DynamicParameters();
            p.Add("p_eventId", eventId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("event_package.DeleteEvent", p, commandType: CommandType.StoredProcedure);
        }

    }
}
