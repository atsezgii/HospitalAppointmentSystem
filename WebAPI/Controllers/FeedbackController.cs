using Application.Features.Doctors.Commands.Delete;
using Application.Features.DoctorSchedule.Commands.Update;
using Application.Features.DoctorSchedule.Queries.GetList;
using Application.Features.Feedbacks.Commands.Create;
using Application.Features.Feedbacks.Commands.Delete;
using Application.Features.Feedbacks.Commands.Update;
using Application.Features.Feedbacks.Queries.GetById;
using Application.Features.Feedbacks.Queries.GetList;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListFeedbackQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteFeedbackCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFeedbackCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
