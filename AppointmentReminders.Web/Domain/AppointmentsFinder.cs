using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;

namespace AppointmentReminders.Web.Domain
{
    public class AppointmentsFinder
    {
        public static IList<Appointment> FindAvailableAppointments(IAppointmentRepository repository, DateTime currentTime)
        {
            var availableAppointments = repository.FindAll()
                .Where(appointment => AppointmentsNotificationPolicy.NeedsToBeSent(appointment, currentTime));


            return availableAppointments.ToList();
        }
    }
}