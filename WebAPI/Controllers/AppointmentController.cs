using Application.Features.Admins.Queries.GetList;
using Application.Features.Appointment.Commands.Create;
using Application.Features.Appointment.Queries.GetById;
using Application.Features.Appointment.Queries.GetList;
using Application.Features.Patients.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : BaseController
    {
       
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateAppointmentCommand command)
        {
            CreateAppointmentResponse response =  await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListAppointmentQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
