using System;
using AppointmentReminders.Web.Models;

namespace AppointmentReminders.Web.Domain
{
    public class AppointmentsNotificationPolicy
    {
        private readonly Appointment _appointment;
        private readonly ITimeConverter _timeConverter;

        public AppointmentsNotificationPolicy(Appointment appointment, ITimeConverter timeConverter)
        {
            _appointment = appointment;
            _timeConverter = timeConverter;
        }

        public bool NeedsToBeSent(DateTime currentTime)
        {
            var reminderLocalTime = GetAppointmentLocalTime()
                .AddMinutes(- Appointment.ReminderTime); // Appointment time - 30 minutes

            return currentTime.ToString("MM/dd/yyyy HH:mm") == reminderLocalTime.ToString("MM/dd/yyyy HH:mm");
        }

        private DateTime GetAppointmentLocalTime()
        {
            return _timeConverter.ToLocalTime(_appointment.Time, _appointment.Timezone);
        }
    }
}