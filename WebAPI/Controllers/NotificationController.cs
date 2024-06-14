using Application.Features.Feedbacks.Commands;
using Application.Features.Notifications.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseController
    {
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateNotificationCommand command)
        {
            CreateNotificationResponse response = await _mediator.Send(command);
            return Ok(response);

        }

    }
}
