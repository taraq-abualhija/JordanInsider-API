using JordanInsider.Core.Models;
using System.Collections.Generic;

namespace JordanInsider.Core.Services
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(decimal ticketId);
        List<Ticket> GetTicketsByUserId(decimal userId);
        List<Ticket> GetTicketsByEventId(decimal eventId);
        Ticket GetTicketsByUserIdAndEventId(decimal userId, decimal eventId);
        void CreateTicket(Ticket ticketData);
        void UpdateTicket(Ticket ticketData);
        void DeleteTicket(decimal ticketId);
    }
}
