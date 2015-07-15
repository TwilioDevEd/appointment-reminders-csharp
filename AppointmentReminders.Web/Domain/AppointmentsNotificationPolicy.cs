using System;
using AppointmentReminders.Web.Extensions;
using AppointmentReminders.Web.Models;

namespace AppointmentReminders.Web.Domain
{
    public class AppointmentsNotificationPolicy
    {
        public static bool NeedsToBeSent(Appointment appointment, DateTime currentTime)
        {
            var appointmentLocalTime = appointment.Time
                .ToLocalTime(appointment.Timezone)
                .AddMinutes(- Appointment.ReminderTime); // Appointment time - 30 minutes

            return currentTime.ToString("MM/dd/yyyy HH:mm") == appointmentLocalTime.ToString("MM/dd/yyyy HH:mm");
        }
    }
}