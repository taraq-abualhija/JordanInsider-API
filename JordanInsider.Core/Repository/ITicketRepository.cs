using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Repository
{
    public interface ITicketRepository
    {
        List<Ticket> GetAllTickets();
        Ticket GetTicketById(decimal id);
        void CreateTicket(Ticket ticketData);
        void UpdateTicket(Ticket ticketData);
        void DeleteTicket(decimal id);
    }
}
