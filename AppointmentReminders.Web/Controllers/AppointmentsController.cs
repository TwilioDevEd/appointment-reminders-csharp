using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;

namespace AppointmentReminders.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentsController() : this(new AppointmentRepository()) { }

        public AppointmentsController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public SelectListItem[] Timezones
        {
            get
            {
                var systemTimeZones = TimeZoneInfo.GetSystemTimeZones();
                return systemTimeZones.Select(systemTimeZone => new SelectListItem
                {
                    Text = systemTimeZone.DisplayName,
                    Value = systemTimeZone.Id
                }).ToArray();
            }
        }

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = _repository.FindAll();
            return View(appointments);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appointment = _repository.FindById(id.Value);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.Timezones = Timezones;
            // Use an empty appointment to setup the default
            // values.
            var appointment = new Appointment
            {
                Timezone = "Pacific Standard Time",
                Time = DateTime.Now
            };

            return View(appointment);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include="ID,Name,PhoneNumber,Time,Timezone")]Appointment appointment)
        {
            appointment.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                _repository.Create(appointment);

                return RedirectToAction("Details", new {id = appointment.Id});
            }

            return View("Create", appointment);
        }

        // GET: Appointments/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appointment = _repository.FindById(id.Value);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            ViewBag.Timezones = Timezones;
            return View(appointment);
        }

        // POST: /Appointments/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,PhoneNumber,Time,Timezone")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(appointment);
                return RedirectToAction("Details", new { id = appointment.Id });
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}