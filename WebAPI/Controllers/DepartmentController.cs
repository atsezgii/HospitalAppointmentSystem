using Application.Features.Departments.Commands.Create;
using Application.Features.Doctors.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateDepartmentCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }
    }
}
