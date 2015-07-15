using System;
using System.Collections.Generic;
using AppointmentReminders.Web.Domain;
using AppointmentReminders.Web.Models;
using Appointments.Web.Tests.Model;
using NUnit.Framework;

namespace Appointments.Web.Tests.Domain
{
    public class AppointmentsFinderTest
    {
        [Test]
        public void FindAvailableAppointments_returns_the_available_appointments()
        {
            var repository = new InMemoryAppointmentRepository();
            var johnAppointment = new Appointment
            {
                Time = new DateTime(2015, 7, 15, 12, 00, 00),
                Timezone = "W. Australia Standard Time"
            };

            var aliceAppointment = new Appointment
            {
                Time = new DateTime(2015, 7, 15, 12, 00, 00),
                Timezone = "SA Pacific Standard Time"
            };

            repository.Create(johnAppointment);
            repository.Create(aliceAppointment);

            var currentTime = new DateTime(2015, 7, 15, 11, 30, 00);

            var availableAppointments = AppointmentsFinder.FindAvailableAppointments(repository, currentTime);

            CollectionAssert.AreEqual(new List<Appointment> {aliceAppointment}, availableAppointments);
        }
    }
}
