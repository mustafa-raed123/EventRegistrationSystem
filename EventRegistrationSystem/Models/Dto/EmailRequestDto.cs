namespace EventRegistrationSystem.Models.Dto
{
    public class EmailRequestDto
    {
        public string recipientEmail {  get; set; }
        public string participantName {  get; set; }
        public int EventId {  get; set; } 
    }
}
