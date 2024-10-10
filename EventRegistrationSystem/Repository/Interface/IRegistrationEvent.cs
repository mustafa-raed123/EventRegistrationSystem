using EventRegistrationSystem.Models.Dto;
using EventRegistrationSystem.Models.Entity;

namespace EventRegistrationSystem.Repository.Interface
{
    public interface IRegistrationEvent
    {
        Task<List<Event>> EventListCard();
        Task<bool> AddParticipant(RegisterReguestDto registerReguestDto);
    }
}
