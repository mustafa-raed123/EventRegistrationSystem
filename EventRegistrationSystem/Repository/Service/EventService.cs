using EventRegistrationSystem.Models.Data;
using EventRegistrationSystem.Models.Dto;
using EventRegistrationSystem.Models.Entity;
using EventRegistrationSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationSystem.Repository.Service
{
    public class EventService : IEvent
    {
        private readonly EventDbContext context;

        public EventService(EventDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Event>> EventList()
        {
            var events = await context.events.ToListAsync();
            return events;

        }
        public async Task CreateEvent(EventRequestDto CreateEvent)
        {
            var newEvent = new Event
            {
                Title = CreateEvent.Title,
                Capacity = CreateEvent.Capacity,
                CreatedDate = CreateEvent.EventDate,
                Description = CreateEvent.Description,
            };
            context.events.Add(newEvent);
            await context.SaveChangesAsync();
        }
        public async Task UpdateEventAsync(int id, Event editEvent)
        {
            var existingEvent = await context.events.FindAsync(id);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException("Event not found.");
            }

            // Update properties
            existingEvent.Title = editEvent.Title;
            existingEvent.Capacity = editEvent.Capacity;
            existingEvent.CreatedDate = editEvent.CreatedDate; // Ensure the correct property is used
            existingEvent.Description = editEvent.Description;

            // Mark the existing event as modified and save
            await context.SaveChangesAsync();
        }
        public async Task DeleteEventAsync(int id)
        {
            var existingEvent = await context.events.FindAsync(id);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException("Event not found.");
            }

            context.events.Remove(existingEvent);
            await context.SaveChangesAsync();
        }
        public async Task<Event> GetEventById(int id)
        {
           var events =  await context.events.FindAsync(id);
            if (events == null) {
                return null;
            
            }
            return events;
        }

    }
}