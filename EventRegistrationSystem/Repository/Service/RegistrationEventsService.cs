using EventRegistrationSystem.Models.Data;
using EventRegistrationSystem.Models.Dto;
using EventRegistrationSystem.Models.Entity;
using EventRegistrationSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace EventRegistrationSystem.Repository.Service
{
    public class RegistrationEventsService : IRegistrationEvent
    {
        private readonly EventDbContext context;
        public RegistrationEventsService(EventDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddParticipant(RegisterReguestDto registerReguestDto)
        {
           var IsTheEmailInTHisEvent = await context.registrationEvents
                .Where(e=>e.Email == registerReguestDto.Email && e.EventId == registerReguestDto.EventId)
                .FirstOrDefaultAsync();
            if (IsTheEmailInTHisEvent !=null)
            {
                return false;
            }
            var RegisterEvent = new RegistrationEvent
            {
                ParticipantName = registerReguestDto.ParticipantName,
                Email = registerReguestDto.Email,
                EventId = registerReguestDto.EventId
            };
            
            context.registrationEvents.Add(RegisterEvent);
            var Event = await context.events.FindAsync(registerReguestDto.EventId);
            if(Event != null)
            {
            Event.Capacity -= 1;
             var recordsAffected = await context.SaveChangesAsync();
                if (recordsAffected > 0)
                    return true;

            }
            return false;

        }
        public async Task<List<Event>> EventListCard()
        {
            var events = await context.events.ToListAsync();
            return events;
        }

       
    }
}
