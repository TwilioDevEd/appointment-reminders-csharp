using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentReminders.Web.Models;
using AppointmentReminders.Web.Models.Repository;

namespace Appointments.Web.Tests.Model
{
    public class InMemoryAppointmentRepository : IAppointmentRepository
    {
        private readonly IList<Appointment> _db = new List<Appointment>();
        public void Create(Appointment appointment)
        {
            _db.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            if (_db.Any(x => x.Id != appointment.Id))
            {
                _db.Remove(appointment);
                _db.Add(appointment);    
            }
        }

        public void Delete(int id)
        {
            _db.Remove(FindById(id));
        }

        public Appointment FindById(int id)
        {
            return _db.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Appointment> FindAll()
        {
            return _db.ToList();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
