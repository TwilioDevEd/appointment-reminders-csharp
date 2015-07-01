using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppointmentReminders.Web.Models
{
    public class AppointmentRemindersContext : DbContext
    {
        public AppointmentRemindersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}