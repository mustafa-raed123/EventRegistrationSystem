using EventRegistrationSystem.Models.Data;
using EventRegistrationSystem.Models.Dto;
using EventRegistrationSystem.Models.Entity;
using EventRegistrationSystem.Repository.Interface;
using EventRegistrationSystem.Repository.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationSystem.Controllers
{
    public class EventController : Controller
    {
       
        private readonly IEvent _event;

        public EventController( IEvent events)
        {
           
            this._event = events;
        }

        // GET: Event/EventsList
        [HttpGet]
        public async Task<IActionResult> EventsList()
        {
            var events = await _event.EventList();
            return View(events);
        }

        // GET: Event/CreateEvent
        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View(new EventRequestDto());
        }

        // POST: Event/CreateEvent
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventRequestDto eventRequest)
        {
            if (ModelState.IsValid)
            {
                await _event.CreateEvent(eventRequest);
                return RedirectToAction("EventsList");
            }
            return View(eventRequest);
        }

        // GET: Event/EditEvent/{id}
        [HttpGet]
        public async Task<IActionResult> EditEvent(int id)
        {
            var eventEntity = await _event.GetEventById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
            return View(eventEntity); 
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                await _event.UpdateEventAsync(eventModel.Id, eventModel); // Ensure the ID is included
                return RedirectToAction("EventsList"); // Or another action
            }
            return View(eventModel); // Return the same model for validation errors
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var existingEvent = await _event.GetEventById(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            return View(existingEvent);
        }

        // POST: Event/DeleteEvent/{id}
        [HttpPost, ActionName("DeleteEvent")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _event.DeleteEventAsync(id);
            return RedirectToAction("EventsList");
        }

        // GET: Event/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var existingEvent = await _event.GetEventById(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            return View(existingEvent);
        }
    }
}
