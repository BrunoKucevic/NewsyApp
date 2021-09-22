using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsy.Application.Users.Commands.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.Controllers
{
    public class UsersController : BaseController
    {
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
