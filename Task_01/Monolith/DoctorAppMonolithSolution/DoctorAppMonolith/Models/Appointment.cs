using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorAppMonolith.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = new Doctor();
    }
}
