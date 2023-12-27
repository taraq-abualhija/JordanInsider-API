using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Service
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        Event GetEventById(decimal id);
        void CreateEvent(Event eventData);
        void UpdateEvent(Event eventData);
        void DeleteEvent(decimal id);
    }
}
