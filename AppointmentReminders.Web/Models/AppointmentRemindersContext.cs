using System.Data.Entity;

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