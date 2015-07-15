using System;
using System.Collections.Generic;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models;
using Appointments.Web.Tests.Model;
using Moq;
using NUnit.Framework;

namespace Appointments.Web.Tests.Domain
{
    public class AppointmentsFinderTest
    {
        [Test]
        public void FindAvailableAppointments_returns_the_available_appointments()
        {
            var repository = new InMemoryAppointmentRepository();

            var appointment = new Appointment();
            repository.Create(appointment);

            var mockTimeConverter = new Mock<ITimeConverter>();

            // For test purposes lets assume the local timezone is Pacific Standard Time.
            mockTimeConverter.Setup(x => x.ToLocalTime(It.IsAny<DateTime>(), It.IsAny<String>()))
                .Returns(new DateTime(2015, 07, 15, 12, 00, 00));

            var appointmentsFinder = new AppointmentsFinder(repository, mockTimeConverter.Object);

            var currentTime = new DateTime(2015, 7, 15, 11, 30, 00);
            var availableAppointments = appointmentsFinder.FindAvailableAppointments(currentTime);

            CollectionAssert.Contains(availableAppointments, appointment);
        }

        [Test]
        public void FindAvailableAppointments_returns_an_empty_list_if_there_are_not_available_appointments()
        {
            var repository = new InMemoryAppointmentRepository();

            var appointment = new Appointment();
            repository.Create(appointment);

            var mockTimeConverter = new Mock<ITimeConverter>();

            // For test purposes lets assume the local timezone is Pacific Standard Time.
            mockTimeConverter.Setup(x => x.ToLocalTime(It.IsAny<DateTime>(), It.IsAny<String>()))
                .Returns(new DateTime(2015, 07, 15, 12, 01, 00));

            var appointmentsFinder = new AppointmentsFinder(repository, mockTimeConverter.Object);

            var currentTime = new DateTime(2015, 7, 15, 11, 30, 00);
            var availableAppointments = appointmentsFinder.FindAvailableAppointments(currentTime);

            Assert.That(availableAppointments, Is.Empty);
        }
    }
}
