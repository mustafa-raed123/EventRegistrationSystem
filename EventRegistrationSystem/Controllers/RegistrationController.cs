using EventRegistrationSystem.Models.Dto;
using EventRegistrationSystem.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EventRegistrationSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationEvent registration;
        private readonly IEmail email;

        public RegistrationController(IRegistrationEvent registration , IEmail email)
        {
            this.registration = registration;
            this.email = email;
        }

        public async Task<IActionResult> EventsList()
        {
            var events = await registration.EventListCard();
            return View(events);
        }
        public IActionResult ShowRegistration(int eventId) {
            var RegisterForm = new RegisterReguestDto {
             EventId = eventId            
            };
            Console.WriteLine("///////////////////////////////");
            Console.WriteLine(RegisterForm.EventId);
            Console.WriteLine("///////////////////////////////");
            return View(RegisterForm);
          
        }
        [HttpPost]
        public async Task<IActionResult> ShowRegistration(RegisterReguestDto registerReguestDto)
        {

            if (ModelState.IsValid)
            {
                var IsConfarmed = await email.SendEmail(registerReguestDto.Email, registerReguestDto.ParticipantName, registerReguestDto.EventId);
                if (IsConfarmed)
                {
                    var resultMessage = await registration.AddParticipant(registerReguestDto);
                    if(resultMessage)
                    return RedirectToAction("EventsList");

                }
                else
                {

                    Console.WriteLine("$$$$$$$$$$$$$$$$$");
                    Console.WriteLine("not Confarmid");
                    Console.WriteLine("$$$$$$$$$$$$$$$$$");
                }

                
            }

            return View("ShowRegistration", registerReguestDto);
        }

    }
}
