using System.ComponentModel.DataAnnotations;

namespace Lab10.Models
{
    public class ConsultationForm
    {
        [Required(ErrorMessage = "Name and Surname must be entered!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The 'Email' field must be entered!")]
        [EmailAddress(ErrorMessage = "Wrong Email type. Please enter the correct one!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This filed must be entered!")]
        [FutureDateValidation(ErrorMessage = "The date should be in future only!")]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Please choose the product")]
        public string ChosenProduct { get; set; }
    }
    public class FutureDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date.Date > DateTime.Now.Date && date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Please enter a future date that is not a weekend.");
        }
    }
}

