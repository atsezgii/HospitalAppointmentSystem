using Application.Features.AdminActions.Commands.Delete;
using Application.Features.AdminActions.Queries.GetList;
using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Delete;
using Application.Features.Admins.Queries.GetById;
using Application.Features.Admins.Queries.GetList;
using Application.Features.Appointment.Commands.Create;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateAdminCommand command)
        {
            CreateAdminResponse response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteAdminCommand command = new() { Id = id };
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
        public async Task<IActionResult> GetAll([FromQuery] GetListAdminQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
