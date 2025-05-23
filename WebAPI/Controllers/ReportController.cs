﻿
using Application.Features.Reports.Commands.Create;
using Application.Features.Reports.Commands.Delete;
using Application.Features.Reports.Commands.Update;
using Application.Features.Reports.Queries.GetById;
using Application.Features.Reports.Queries.GetList;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdQuery query = new() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListReportQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteReportCommand command = new() { Id = id };
            await _mediator.Send(command);
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReportCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
