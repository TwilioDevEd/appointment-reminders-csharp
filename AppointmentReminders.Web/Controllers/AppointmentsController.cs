using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AppointmentReminders.Web.Models;

namespace AppointmentReminders.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppointmentRemindersContext _context = new AppointmentRemindersContext();

        // GET: Appointments
        public async Task<ActionResult> Index()
        {
            var appointments = _context.Appointments;

            return View(await appointments.ToListAsync());

        }

        // GET: Appointments/Details/5

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include="ID,Name,PhoneNumber")]Appointment appointment)
        {
            // TODO: Include the proper controls, add an AppointmentViewModel
            appointment.Time = new DateTime(2015, 07, 02, 10, 11, 12);
            appointment.CreatedAt = new DateTime(2015, 07, 02, 10, 11, 12);

            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return RedirectToAction("Edit", new {id = appointment.Id});
            }

            return View(appointment);
        }

        // GET: Appointments/Edit/5

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View(appointment);

        }

        // POST: /Participants/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,PhoneNumber")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(appointment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
    }
}
