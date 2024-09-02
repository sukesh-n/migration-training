using DoctorAppMonolith.Models;

namespace DoctorAppMonolith.Interface
{
    public interface IAppointmentService
    {
        public Task<Appointment> AddAppointment(Appointment appointment);

    }
}
