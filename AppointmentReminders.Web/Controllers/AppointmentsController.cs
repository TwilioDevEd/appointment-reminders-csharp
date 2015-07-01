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

        // GET: Appointments/Create

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(FormCollection collection)
        {

            return View();
        }

        // GET: Appointments/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Find participant

            return View(new Appointment());

        }
    }
}
