using System;
using System.Collections.Generic;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;
using WebGrease.Css.Extensions;

namespace AppointmentReminders.Web.Workers
{
    public class SendNotificationsJob
    {
        private const string MessageTemplate =
            "Hi {0}. Just a reminder that you have an appointment coming up at {1}.";

        public void Execute()
        {
            var twilioRestClient = new Domain.Twilio.RestClient();

            AvailableAppointments().ForEach(appointment =>
                twilioRestClient.SendSmsMessage(
                appointment.PhoneNumber,
                string.Format(MessageTemplate, appointment.Name, appointment.Time.ToString("t"))));
        }

        private static IEnumerable<Appointment> AvailableAppointments()
        {
            return new AppointmentsFinder(new AppointmentRepository(), new TimeConverter())
                .FindAvailableAppointments(DateTime.Now);
        }
    }
}