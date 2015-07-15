using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models;
using NUnit.Framework;

namespace Appointments.Web.Tests.Domain
{
    public class AppointmentsNotificationPolicyTest
    {
        [TestCase(29, false)]
        [TestCase(30, true)]
        public void NeedsToBeSent_returns_true_if_the_given_appointment_matches_the_current_time(
            int minute, bool expectedResult)
        {
            var currentTime = new DateTime(2015, 07, 15, 13, minute, 00);
            var appointment = new Appointment
            {
                Time = new DateTime(2015, 07, 15, 12, 00, 00),
                Timezone = "Pacific Standard Time"
            };

            var result = AppointmentsNotificationPolicy.NeedsToBeSent(appointment, currentTime);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
