using RapportCQRS.Domain.Commands.Activity;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries.Activity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RapportCQRS.API.V1.Controllers
{
    [AllowAnonymous]
    
    public class ActivityController : ApiV1ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(ILogger<ActivityController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get Activity by id
        /// </summary>
        /// <param name="id">Id of Activity</param>
        /// <returns>Activity information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ActivityDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ActivityDto>> GetActivityAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetActivityQuery(id)));
        }

        /// <summary>
        /// Get all Activitys
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<ActivityDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<ActivityDto>>> GetActivitysAsync([FromQuery] GetActivitiesQuery query)
        {
            return await QueryAsync<PagedResults<ActivityDto>>(query);
        }

        /// <summary>
        /// Create new Activity
        /// </summary>
        /// <param name="command">Info of Activity</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateActivityAsync([FromBody] CreateActivityCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new Activity
        /// </summary>
        /// <param name="command">Info of Activity</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateActivityAsync([FromBody] UpdateActivityCommand command)
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
        public async Task<ActionResult<ActivityDto>> DeleteActivityAsync([FromBody] DeleteActivityCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}