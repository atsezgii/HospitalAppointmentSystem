using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Patients.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : BaseController
    {
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateFeedbackCommand command)
        {
            CreateFeedbackResponse response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
