using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newsy.Models;
using Newsy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [AllowAnonymous]
        [HttpPost, Route("request")]
        public async Task<IActionResult> RequestToken([FromBody] TokenRequest request)
        {
            var userDetail = await _authenticateService.AuthenticateUserWithUsernameAndPassword(request.Username, request.Password);
            string token = string.Empty;
            string refreshToken = string.Empty;

            if (userDetail != null)
            {
                token = await _authenticateService.GenerateTokenAsync(userDetail);
                refreshToken = _authenticateService.GenerateRefreshToken(request.Username);

                return Ok(
                    new
                    {
                        token,
                        refreshToken
                    });
            }

            return BadRequest("Invalid Request");
        }

    }
}
