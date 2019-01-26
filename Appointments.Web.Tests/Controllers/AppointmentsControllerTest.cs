using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AppointmentReminders.Web.Controllers;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;
using Appointments.Web.Tests.Model;
using NUnit.Framework;

namespace Appointments.Web.Tests.Controllers
{
    public class AppointmentsControllerTest
    {
        [Test]
        public void Index_returns_a_list_of_the_existing_appointments()
        {
            var repository = new InMemoryAppointmentRepository();
            repository.Create(MakeAppointment(1, "John"));
            repository.Create(MakeAppointment(2, "Jane"));
            var controller = GetAppointmentsController(repository);
            var result = controller.Index() as ViewResult;

            Assert.That(result.ViewData.Model, Is.EqualTo(repository.FindAll()));
        }

        [Test]
        public void Create_Appointment_returns_view_if_the_model_is_invalid()
        {
            var controller = GetAppointmentsController(new InMemoryAppointmentRepository());
            controller.ModelState.AddModelError("", "Name is required");

            var appointment = MakeAppointment();
            var result = controller.Create(appointment) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Create"));
        }

        [Test]
        public void Create_Appointment_creates_an_appointment_when_the_model_is_valid()
        {
            var repository = new InMemoryAppointmentRepository();
            var controller = GetAppointmentsController(repository);

            var appointment = MakeAppointment();
            controller.Create(appointment);

            var appointments = repository.FindAll();

            Assert.That(appointments, Contains.Item(appointment));
        }

        [Test]
        public void Create_Appointment_redirects_to_details_view_on_success()
        {
            var controller = GetAppointmentsController(new InMemoryAppointmentRepository());
            var appointment = MakeAppointment();

            var result = (RedirectToRouteResult)controller.Create(appointment);

            Assert.That(result.RouteValues["action"], Is.EqualTo("Details"));
        }

        [Test]
        public void Update_Appointment_updates_an_appointment_on_repository()
        {
            var repository = new InMemoryAppointmentRepository();
            repository.Create(MakeAppointment(1, "John"));

            var controller = GetAppointmentsController(repository);
            controller.Edit(MakeAppointment(1, "Charles"));

            Assert.That(repository.FindById(1).Name, Is.EqualTo("Charles"));
        }

        [Test]
        public void Update_Appointment_redirects_to_details_view_on_success()
        {
            var controller = GetAppointmentsController(new InMemoryAppointmentRepository());
            var appointment = MakeAppointment();

            var result = (RedirectToRouteResult)controller.Create(appointment);

            Assert.That(result.RouteValues["action"], Is.EqualTo("Details"));
        }


        [Test]
        public void Delete_Appointment_removes_an_appointment_from_repository()
        {
            var appointment = MakeAppointment();

            var repository = new InMemoryAppointmentRepository();
            repository.Create(appointment);

            var controller = GetAppointmentsController(repository);
            controller.Delete(appointment.Id);

            Assert.That(repository.FindAll(), !Contains.Item(appointment));
        }

        [Test]
        public void Delete_Appointment_redirects_to_index_view_on_success()
        {
            var appointment = MakeAppointment();

            var repository = new InMemoryAppointmentRepository();
            repository.Create(appointment);

            var controller = GetAppointmentsController(new InMemoryAppointmentRepository());
            var result = (RedirectToRouteResult)controller.Delete(appointment.Id);

            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));
        }

        private static AppointmentsController GetAppointmentsController(IAppointmentRepository repository)
        {
            var controller = new AppointmentsController(repository);

            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };

            return controller;
        }

        private static Appointment MakeAppointment()
        {
            return new Appointment {Id = 1, Name = "John", PhoneNumber = "1234"};
        }

        private static Appointment MakeAppointment(int id, string name)
        {
            return new Appointment { Id = id, Name = name, PhoneNumber = "1234" };
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
    }
}
