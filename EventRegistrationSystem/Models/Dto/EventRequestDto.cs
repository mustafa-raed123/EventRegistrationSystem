﻿using EventRegistrationSystem.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models.Dto
{
    public class EventRequestDto
    {
        [Required(ErrorMessage = "the title is required.")]

        [StringLength(50, MinimumLength = 4, ErrorMessage = "The field must be between 4 and 50 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "the Capacity is required.")]
        public int Capacity { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "The field must be between 10 and 200 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The date is required.")]
        [FutureDate(ErrorMessage = "The date must be today or in the future.")]
        public DateTime EventDate { get; set; }

    }
}