using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models;
using Twilio;

namespace AppointmentReminders.Web.Workers
{
    public class SendNotificationsJob
    {
        private readonly AppointmentRemindersContext _context = new AppointmentRemindersContext();

        public TwilioRestClient TwilioClient
        {
            get
            {
                var accountSid = WebConfigurationManager.AppSettings["AccountSid"];
                var authToken = WebConfigurationManager.AppSettings["AuthToken"];

                return new TwilioRestClient(accountSid, authToken);
            }
        }

        public void Execute()
        {
            const string messageTemplate =
                "Hi {0}. Just a reminder that you have an appointment coming up at {1}.";

            var appointments = GetAppointments();

            if (appointments.Count == 0)
            {
                return;
            }

            var twilioNumber = WebConfigurationManager.AppSettings["TwilioNumber"];

            foreach (var appointment in appointments)
            {
                TwilioClient.SendSmsMessage(
                    twilioNumber,
                    appointment.PhoneNumber,
                    string.Format(messageTemplate, appointment.Name, appointment.Time));
            }
        }

        public IList<Appointment> GetAppointments()
        {
            var availableAppointments = _context.Appointments.Where(
                appointment => AppointmentsNotificationPolicy.NeedsToBeSent(appointment));

            return availableAppointments.ToList();
        }
    }
}