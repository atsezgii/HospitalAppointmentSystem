using Application.Features.Feedbacks.Commands;
using Application.Features.Notifications.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateNotificationCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }
    }
}
