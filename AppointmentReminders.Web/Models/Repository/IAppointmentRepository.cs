using System.Collections.Generic;

namespace AppointmentReminders.Web.Models.Repository
{
    public interface IAppointmentRepository
    {
        void Create(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(int id);
        Appointment FindById(int id);
        IEnumerable<Appointment> FindAll();
    }
}
