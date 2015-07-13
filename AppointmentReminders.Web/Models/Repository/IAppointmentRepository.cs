using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentReminders.Web.Models.Repository
{
    public interface IAppointmentRepository
    {
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(int id);
        Appointment FindById(int id);
        IEnumerable<Appointment> FindAll();
        int SaveChanges();
    }
}
