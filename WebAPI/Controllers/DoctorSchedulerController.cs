using Application.Features.Appointment.Commands.Create;
using Application.Features.DoctorSchedule.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorSchedulerController : BaseController
    {

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateDoctorScheduleCommand command)
        {
            CreateDoctorScheduleResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
