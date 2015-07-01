using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppointmentReminders.Web.Models;

namespace AppointmentReminders.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments

        public ActionResult Index()
        {
            var appointments = new List<Appointment>
            {
               new Appointment{Id = 1, Name = "Frank", PhoneNumber = "+593992670240",Time = new DateTime(), CreatedAt = new DateTime() } 
            };
            return View(appointments);

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
