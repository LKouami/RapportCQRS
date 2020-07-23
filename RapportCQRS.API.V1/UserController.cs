using RapportCQRS.Domain.Commands.User;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries.User;
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
    
    public class UserController : ApiV1ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id">Id of User</param>
        /// <returns>User information</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUserAsync(Int64 id)
        {
            return Single(await QueryAsync(new GetUserQuery(id)));
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResults<UserDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PagedResults<UserDto>>> GetUsersAsync([FromQuery] GetUsersQuery query)
        {
            return await QueryAsync<PagedResults<UserDto>>(query);
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="command">Info of User</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            return StatusCode(200, await CommandAsync(command));
        }

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="command">Info of User</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UpdateUserCommand command)
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
        public async Task<ActionResult<UserDto>> DeleteUserAsync([FromBody] DeleteUserCommand command)
        {
            return StatusCode(204, await CommandAsync(command));
        }

    }
}