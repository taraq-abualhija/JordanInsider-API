using JordanInsider.Core.Models;
using JordanInsider.Core.Service;
using JordanInsider.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JordanInsider.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService _ticketService)
        {
            ticketService = _ticketService;
        }

        [HttpGet]
        [Route("GetAllTickets")]
        public IActionResult GetAllTickets()
        {
            try
            {
                var tickets = ticketService.GetAllTickets();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving tickets: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTicketById/{id}")]
        public IActionResult GetTicketById(decimal id)
        {
            try
            {
                var ticket = ticketService.GetTicketById(id);
                if (ticket == null)
                    return NotFound();

                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the ticket: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTicketsByUserId/{userId}")]
        public IActionResult GetTicketsByUserId(decimal userId)
        {
            try
            {
                var tickets = ticketService.GetTicketsByUserId(userId);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving tickets: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTicketsByEventId/{eventId}")]
        public IActionResult GetTicketsByEventId(decimal eventId)
        {
            try
            {
                var tickets = ticketService.GetTicketsByEventId(eventId);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving tickets: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTicketsByUserIdAndEventId/{userId}/{eventId}")]
        public IActionResult GetTicketsByUserIdAndEventId(decimal userId, decimal eventId)
        {
            try
            {
                var ticket = ticketService.GetTicketsByUserIdAndEventId(userId, eventId);
                if (ticket == null)
                    return NotFound();

                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the ticket: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateTicket")]
        public IActionResult CreateTicket(Ticket ticketData)
        {
            try
            {
                ticketService.CreateTicket(ticketData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the ticket: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTicket")]
        public IActionResult UpdateTicket(Ticket ticketData)
        {
            try
            {
                ticketService.UpdateTicket(ticketData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the ticket: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTicket/{id}")]
        public IActionResult DeleteTicket(decimal id)
        {
            try
            {
                ticketService.DeleteTicket(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the ticket: " + ex.Message);
            }
        }
    }
}
