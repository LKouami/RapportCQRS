//using RapportCQRS.Domain.Commands.User;
//using RapportCQRS.Domain.Queries.User;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace RapportCQRS.API.V1.Controllers
//{
//    public class AuthController : ApiV1ControllerBase
//    {
//        public AuthController(IMediator mediator) : base(mediator)
//        {
//        }

//        /// <summary>
//        /// Login the user
//        /// </summary>
//        /// <param name="command">Info of User</param>
//        /// <returns></returns>
//        [AllowAnonymous]
//        [HttpPost("login")]
//        [ProducesResponseType(200)]
//        [ProducesResponseType(404)]
//        public async Task<ActionResult> LoginAsync([FromBody] GetLoginQuery query)
//        {
//            string token = await QueryAsync(query);

//            if (string.IsNullOrWhiteSpace(token))
//            {
//                return NotFound();
//            }
//            else
//            {
//                return Ok(token);
//            }
            
//        }

//        /// <summary>
//        /// Logout the user
//        /// </summary>
//        /// <param name="command">Logout token</param>
//        /// <returns></returns>
//        [AllowAnonymous]
//        [HttpPost("logout")]
//        [ProducesResponseType(200)]
//        [ProducesResponseType(404)]
//        public ActionResult LogoutAsync([FromBody] LogoutCommand command)
//        {
//            // TODO : Invalidate the token
//            return  Ok();
//        }

//    }
//}