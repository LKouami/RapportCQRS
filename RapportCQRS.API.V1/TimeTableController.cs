using RapportCQRS.Domain.Commands.TimeTable;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries.TimeTable;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RapportCQRS.Domain.Queries.Activity;

namespace RapportCQRS.API.V1.Controllers
{
    [AllowAnonymous]
    
    public class TimeTableController : ApiV1ControllerBase
    {
        private readonly ILogger<TimeTableController> _logger;

        public TimeTableController(ILogger<TimeTableController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get TimeTable by id
        /// </summary>
        /// <param name="id">Id of TimeTable</param>
        /// <returns>TimeTable information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(TimeTableDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TimeTableDto>> GetTimeTableAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetTimeTableQuery(id)));
        }

        /// <summary>
        /// Get all TimeTables
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<TimeTableDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<TimeTableDto>>> GetTimeTablesAsync([FromQuery] GetTimeTablesQuery query)
        {
            return await QueryAsync<PagedResults<TimeTableDto>>(query);
        }

        /// <summary>
        /// Create new TimeTable
        /// </summary>
        /// <param name="command">Info of TimeTable</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateTimeTableAsync([FromBody] CreateTimeTableCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new TimeTable
        /// </summary>
        /// <param name="command">Info of TimeTable</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateTimeTableAsync([FromBody] UpdateTimeTableCommand command)
        {
            return Ok(await CommandAsync(command));
        }


        /// <summary>
        /// Delete an employee with an id 
        /// </summary>
        /// <param name="command">The delete model</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(DeleteResult), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TimeTableDto>> DeleteTimeTableAsync([FromBody] DeleteTimeTableCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}