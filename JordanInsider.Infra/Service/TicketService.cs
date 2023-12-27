using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using JordanInsider.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Infra.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepository.GetAllTickets();
        }

        public Ticket GetTicketById(decimal id)
        {
            return _ticketRepository.GetTicketById(id);
        }

        public void CreateTicket(Ticket ticketData)
        {
            _ticketRepository.CreateTicket(ticketData);
        }

        public void UpdateTicket(Ticket ticketData)
        {
            _ticketRepository.UpdateTicket(ticketData);
        }

        public void DeleteTicket(decimal id)
        {
            _ticketRepository.DeleteTicket(id);
        }
    }
}
