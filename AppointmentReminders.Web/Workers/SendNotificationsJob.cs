using System;
using System.Web.Configuration;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models.Repository;
using Twilio;

namespace AppointmentReminders.Web.Workers
{
    public class SendNotificationsJob
    {
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

            var availableAppointments = AppointmentsFinder.FindAvailableAppointments(new AppointmentRepository(), DateTime.Now);

            if (availableAppointments.Count == 0)
            {
                return;
            }

            var twilioNumber = WebConfigurationManager.AppSettings["TwilioNumber"];

            foreach (var appointment in availableAppointments)
            {
                TwilioClient.SendSmsMessage(
                twilioNumber,
                appointment.PhoneNumber,
                string.Format(messageTemplate, appointment.Name, appointment.Time.ToString("t")));
            }
        }
    }
}