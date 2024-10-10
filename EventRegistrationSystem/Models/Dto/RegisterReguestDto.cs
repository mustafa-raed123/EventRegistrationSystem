using EventRegistrationSystem.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models.Dto
{
    public class RegisterReguestDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The Name must be between 5 and 20 characters.")]
        public string ParticipantName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [CustomEmail(ErrorMessage = "Only emails from example@example.com are allowed.")]
        public string Email { get; set; }
        public int EventId { get; set; }
        

    }
}
