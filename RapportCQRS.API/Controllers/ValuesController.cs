using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RapportCQRS.API.Controllers
{
    /// <summary>
    /// Get all
    /// </summary>
    public class ValuesController : ControllerBase
    {
        // GET: Values
        [AllowAnonymous]
        [HttpGet("test")]
        public String Test()
        {
            return "success";
        }
    }
}