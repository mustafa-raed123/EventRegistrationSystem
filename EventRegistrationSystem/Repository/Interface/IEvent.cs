using EventRegistrationSystem.Models.Dto;
using EventRegistrationSystem.Models.Entity;

namespace EventRegistrationSystem.Repository.Interface
{
    public interface IEvent
    {
        Task<List<Event>> EventList();
        Task CreateEvent(EventRequestDto eventRequest);
         Task<Event> GetEventById(int id);
        Task UpdateEventAsync(int id, Event eventRequest);
        Task DeleteEventAsync(int id);
    }
}
