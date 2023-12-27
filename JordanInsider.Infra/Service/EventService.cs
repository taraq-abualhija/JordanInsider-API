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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public Event GetEventById(decimal id)
        {
            return _eventRepository.GetEventById(id);
        }

        public void CreateEvent(Event eventData)
        {
            _eventRepository.CreateEvent(eventData);
        }

        public void UpdateEvent(Event eventData)
        {
            _eventRepository.UpdateEvent(eventData);
        }

        public void DeleteEvent(decimal id)
        {
            _eventRepository.DeleteEvent(id);
        }
    }
}
