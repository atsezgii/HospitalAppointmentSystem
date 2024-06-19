using Application.Features.Admins.Commands.Delete;
using Application.Features.Appointment.Commands.Update;
using Application.Features.Appointment.Queries.GetList;
using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using Application.Features.Doctors.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateDepartmentCommand command)
        {
            CreateDepartmentResponse response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteDepartmentCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deleted");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListDepartmentQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
