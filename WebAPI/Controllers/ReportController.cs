using Application.Features.Patients.Commands.Create;
using Application.Features.Reports.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateReportCommand command)
        {
            CreateReportResponse response = await _mediator.Send(command);
            return Ok(response);

        }
    }
}
