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
    public class TicketRepository : ITicketRepository
    {
        private readonly IDbContext dbContext;

        public TicketRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Ticket> GetAllTickets()
        {
            IEnumerable<Ticket> result = dbContext.Connection.Query<Ticket>("Ticket_Package.GetAllTickets", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ticket GetTicketById(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Ticket>("Ticket_Package_SPEC.GetTicketById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateTicket(Ticket ticketData)
        {
            var p = new DynamicParameters();
            p.Add("EVENTID", ticketData.Eventid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("USERID", ticketData.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("PRICE", ticketData.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Ticket_Package_SPEC.CreateTicket", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTicket(Ticket ticketData)
        {
            var p = new DynamicParameters();
            p.Add("ID", ticketData.Ticketid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("EVENTID", ticketData.Eventid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("USERID", ticketData.Userid, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("PRICE", ticketData.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Ticket_Package_SPEC.UpdateTicket", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTicket(decimal id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("Ticket_Package_SPEC.DeleteTicket", p, commandType: CommandType.StoredProcedure);
        }
    }
}
