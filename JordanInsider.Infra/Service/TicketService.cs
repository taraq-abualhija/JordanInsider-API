using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;

        public TicketService(ITicketRepository _ticketRepository)
        {
            this.ticketRepository = _ticketRepository;
        }

        public List<Ticket> GetAllTickets()
        {
            return ticketRepository.GetAllTickets();
        }

        public Ticket GetTicketById(decimal ticketId)
        {
            return ticketRepository.GetTicketById(ticketId);
        }

        public List<Ticket> GetTicketsByUserId(decimal userId)
        {
            return ticketRepository.GetTicketsByUserId(userId);
        }

        public List<Ticket> GetTicketsByEventId(decimal eventId)
        {
            return ticketRepository.GetTicketsByEventId(eventId);
        }

        public Ticket GetTicketsByUserIdAndEventId(decimal userId, decimal eventId)
        {
            return ticketRepository.GetTicketsByUserIdAndEventId(userId, eventId);
        }

        public void CreateTicket(Ticket ticketData)
        {
            ticketRepository.CreateTicket(ticketData);
        }

        public void UpdateTicket(Ticket ticketData)
        {
            ticketRepository.UpdateTicket(ticketData);
        }

        public void DeleteTicket(decimal ticketId)
        {
            ticketRepository.DeleteTicket(ticketId);
        }
    }
}
