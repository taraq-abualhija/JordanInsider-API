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
    public class TicketRepository : ITicketRepository
    {
        private readonly IDbContext dbContext;

        public TicketRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<Ticket> GetAllTickets()
        {
            IEnumerable<Ticket> result = dbContext.Connection.Query<Ticket>("ticket_package.GetAllTickets", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ticket GetTicketById(decimal ticketId)
        {
            var p = new DynamicParameters();
            p.Add("p_ticketId", ticketId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Ticket>("ticket_package.GetTicketById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Ticket> GetTicketsByUserId(decimal userId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Ticket>("ticket_package.GetTicketsByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Ticket> GetTicketsByEventId(decimal eventId)
        {
            var p = new DynamicParameters();
            p.Add("p_eventId", eventId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Ticket>("ticket_package.GetTicketsByEventId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Ticket GetTicketsByUserIdAndEventId(decimal userId, decimal eventId)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", userId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_eventId", eventId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Query<Ticket>("ticket_package.GetTicketsByUserIdAndEventId", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateTicket(Ticket ticketData)
        {
            var p = new DynamicParameters();
            p.Add("p_userId", ticketData.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_eventId", ticketData.Eventid, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("ticket_package.CreateTicket", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTicket(Ticket ticketData)
        {
            var p = new DynamicParameters();
            p.Add("p_ticketId", ticketData.Ticketid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_userId", ticketData.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("p_eventId", ticketData.Eventid, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("ticket_package.UpdateTicket", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTicket(decimal ticketId)
        {
            var p = new DynamicParameters();
            p.Add("p_ticketId", ticketId, DbType.Int32, ParameterDirection.Input);
            var result = dbContext.Connection.Execute("ticket_package.DeleteTicket", p, commandType: CommandType.StoredProcedure);
        }
    }
}
