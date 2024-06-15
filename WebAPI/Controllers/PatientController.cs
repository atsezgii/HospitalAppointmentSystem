using Application.Features.Auth.Commands.Register;
using Application.Features.Notifications.Queries.GetList;
using Application.Features.Patients.Commands.Create;
using Application.Features.Patients.Queries.GetById;
using Application.Features.Patients.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController
    {

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreatePatientCommand command)
        {
            CreatePatientResponse response = await _mediator.Send(command);
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
        public async Task<IActionResult> GetAll([FromQuery] GetListPatientQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
