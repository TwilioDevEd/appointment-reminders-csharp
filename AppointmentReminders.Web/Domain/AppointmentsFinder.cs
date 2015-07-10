using System.Collections.Generic;
using System.Linq;
using AppointmentReminders.Web.Models;

namespace AppointmentReminders.Web.Domain
{
    public class AppointmentsFinder
    {
        private static readonly AppointmentRemindersContext Context = new AppointmentRemindersContext();

        public static IList<Appointment> GetAvailableAppointments()
        {
            var appointments = Context.Appointments.ToList();
            var availableAppointments = appointments.Where(
                AppointmentsNotificationPolicy.NeedsToBeSent);

            return availableAppointments.ToList();
        }
    }
}