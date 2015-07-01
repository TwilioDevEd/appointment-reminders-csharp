using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace AppointmentReminders.Web.Models
{
    public class Appointment
    {
        // Appointment.Remindertime
        public static int ReminderTime = 30;
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Phone number")]
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "The Phone number is not valid.")]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime Time { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        // TODO: Add callback to setup reminder
        // This processing should be done asynchronously
    }
}