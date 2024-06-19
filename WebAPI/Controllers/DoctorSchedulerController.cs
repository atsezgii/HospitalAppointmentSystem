using Application.Features.Admins.Commands.Delete;
using Application.Features.Appointment.Commands.Create;
using Application.Features.Doctors.Commands.Update;
using Application.Features.Doctors.Queries.GetList;
using Application.Features.DoctorSchedule.Commands;
using Application.Features.DoctorSchedule.Commands.Delete;
using Application.Features.DoctorSchedule.Commands.Update;
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteDoctorScheduleCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDoctorScheduleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
