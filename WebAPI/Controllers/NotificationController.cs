using Application.Features.Doctors.Commands.Delete;
using Application.Features.Feedbacks.Commands;
using Application.Features.Feedbacks.Commands.Update;
using Application.Features.Feedbacks.Queries.GetList;
using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Commands.Delete;
using Application.Features.Notifications.Commands.Update;
using Application.Features.Notifications.Queries.GetById;
using Application.Features.Notifications.Queries.GetList;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListNotificationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteNotificationCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNotificationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
