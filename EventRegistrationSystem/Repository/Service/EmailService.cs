using EventRegistrationSystem.Repository.Interface;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace EventRegistrationSystem.Repository.Service
{
    public class EmailService: IEmail
    {
        private readonly IConfiguration configuration;
        private readonly MailjetClient mailjetClient;

        public EmailService(IConfiguration Configuration)
        {
            configuration = Configuration;
            mailjetClient =new MailjetClient(
                 configuration["mailjet:ApiKey"],
                 configuration["mailjet:SecretKey"]
                );
        }
        public async Task<Boolean> SendEmail(string recipientEmail , string participantName, int EventId)
        {
           var request  =  new MailjetRequest
           {
               Resource = Send.Resource,
           }.Property(Send.FromEmail, "mustafa.raed.mousa@gmail.com").
            Property(Send.FromName , "Events")
           .Property(Send.HtmlPart , $"<h3>Dear {participantName},</h3><p>You have successfully registered for the event with ID {EventId}.</p><p>Thank you!</p>")
           .Property(Send.To , recipientEmail)
            .Property(Send.Subject, "Registration Confirmation");
            var response = await mailjetClient.PostAsync(request);
            return response.IsSuccessStatusCode;

        }
    }
}
