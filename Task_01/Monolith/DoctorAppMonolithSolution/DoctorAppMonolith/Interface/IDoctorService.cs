using DoctorAppMonolith.Models;

namespace DoctorAppMonolith.Interface
{
    public interface IDoctorService
    {
        public Task<Doctor> AddDoctor();
        public Task<List<Doctor>> GetDoctor();
    }
}
