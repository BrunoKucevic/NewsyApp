using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsy.Application.Roles.Queries.GetAllRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController
    {
        [HttpGet("allRoles")]
        public async Task<ActionResult<GetAllRolesViewModel>> GetAllRoles()
        {
            var request = new GetAllRolesRequest();
            GetAllRolesViewModel res = await Mediator.Send(request);

            return Ok(res);
        }
    }
}
