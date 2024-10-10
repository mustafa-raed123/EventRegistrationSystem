using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EventRegistrationSystem.Models.Entity
{
    public class RegistrationEvent
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20 ,MinimumLength =5  , ErrorMessage = "The Name must be between 5 and 20 characters.")]
        public string ParticipantName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [CustomEmail(ErrorMessage = "Only emails from example@example.com are allowed.")]
        public string Email { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

    }
    public class CustomEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string email)
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"); 
            }
            return false;
        }
    }
}
