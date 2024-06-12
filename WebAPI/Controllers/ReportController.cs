using Application.Features.Patients.Commands.Create;
using Application.Features.Reports.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateReportCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }
    }
}
