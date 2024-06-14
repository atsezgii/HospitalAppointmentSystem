using Application.Features.Departments.Commands.Delete;
using Application.Features.Doctors.Commands.Create;
using Application.Features.Doctors.Commands.Delete;
using Application.Features.Patients.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController
    {

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateDoctorCommand command)
        {
            CreateDoctorResponse response = await _mediator.Send(command);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteDoctorCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deleted");
        }
    }
}
