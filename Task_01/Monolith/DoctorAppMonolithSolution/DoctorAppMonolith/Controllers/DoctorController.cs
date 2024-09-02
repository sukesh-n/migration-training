using DoctorAppMonolith.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppMonolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPut("AddDoctor")]
        public async Task<IActionResult> AddDoctor()
        {
            var result = await _doctorService.AddDoctor();
            return Ok(result);
        }
        [HttpPost("GetDoctor")]
        public async Task<IActionResult> GetDoctor()
        {
            var result = await _doctorService.GetDoctor();
            return Ok(result);
        }
    }
}
