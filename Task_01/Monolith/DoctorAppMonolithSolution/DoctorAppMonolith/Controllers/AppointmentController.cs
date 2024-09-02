using DoctorAppMonolith.Interface;
using DoctorAppMonolith.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppMonolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPut]
        public async Task<IActionResult> AddAppointment(Appointment appointment)
        {
            var result = await _appointmentService.AddAppointment(appointment);
            return Ok(result);
        }
    }
}
