using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AppointmentReminders.Web.Models.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentRemindersContext _context = new AppointmentRemindersContext();

        public void Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            _context.Entry(appointment).Property(model => model.CreatedAt).IsModified = false;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointment = FindById(id);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public Appointment FindById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> FindAll()
        {
            return  _context.Appointments.ToList();
        }
    }
}