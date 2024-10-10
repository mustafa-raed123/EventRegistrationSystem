namespace EventRegistrationSystem.Repository.Interface
{
    public interface IEmail
    {
        Task<Boolean> SendEmail(string recipientEmail, string participantName, int EventId);
    }
}
