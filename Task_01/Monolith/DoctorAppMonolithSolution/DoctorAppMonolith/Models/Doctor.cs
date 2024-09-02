using System.ComponentModel.DataAnnotations;

namespace DoctorAppMonolith.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
    }
}
