using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models;
using Moq;
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
            var appointment = new Appointment
            {
                Time = new DateTime(2015, 07, 15, 12, 00, 00),
                Timezone = "Pacific Standard Time"
            };

            // For simplicity lets assume the local timezone is Pacific Standard Time.
            var mockTimeConverter = new Mock<ITimeConverter>();
            mockTimeConverter.Setup(x => x.ToLocalTime(It.IsAny<DateTime>(), It.IsAny<String>()))
                .Returns(new DateTime(2015, 07, 15, 12, 00, 00));

            var currentTime = new DateTime(2015, 07, 15, 11, minute, 00);
            var result = new AppointmentsNotificationPolicy(appointment, mockTimeConverter.Object)
                .NeedsToBeSent(currentTime);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
