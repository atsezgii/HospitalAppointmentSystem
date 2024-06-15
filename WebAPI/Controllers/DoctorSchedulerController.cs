using Application.Features.Appointment.Commands.Create;
using Application.Features.Doctors.Queries.GetList;
using Application.Features.DoctorSchedule.Commands;
using Application.Features.DoctorSchedule.Queries.GetById;
using Application.Features.DoctorSchedule.Queries.GetList;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListDoctorScheduleQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
