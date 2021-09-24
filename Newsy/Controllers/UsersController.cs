using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newsy.Application.Users.Commands.ActivateUser;
using Newsy.Application.Users.Commands.RegisterUser;
using Newsy.Application.Users.Commands.UpdateCurrentUser;
using Newsy.Application.Users.Queries.GetAllUsers;
using Newsy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("getAllUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GetAllUsersViewModel>> GetAllUsers()
        {
            GetAllUsersRequest request = new GetAllUsersRequest();
            GetAllUsersViewModel res = await Mediator.Send(request);

            return res;
        }


        [HttpPost("activate")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ActivateUserViewModel>> ActivateUser([FromBody] ActivateUserRequest request)
        {
            ActivateUserViewModel res = await Mediator.Send(request);

            return res;
        }

        [HttpPost("updateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCurrentUser([FromBody] UpdateCurrentUserRequest request)
        {
            await Mediator.Send(request);

            return NoContent();
        }
    }
}
