using Application.Features.AdminActions.Commands.Create;
using Application.Features.AdminActions.Commands.Delete;
using Application.Features.AdminActions.Queries.GetById;
using Application.Features.AdminActions.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminActionController : BaseController
    {
     
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAdminActionsCommand command)
        {
            CreateAdminActionsResponse response =  await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteAdminActionsCommand command = new() { Id = id };
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
        public async Task<IActionResult> GetAll([FromQuery] GetListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
