using Application.Features.Appointment.Commands.Create;
using Application.Features.Patients.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateAppointmentCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }
    }
}
