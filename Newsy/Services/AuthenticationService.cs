﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newsy.Application.Shared.Exceptions;
using Newsy.Application.Users.Commands.CheckPassword;
using Newsy.Application.Users.Queries.GetUserByUsername;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TripleR.WebUI.Models;

namespace Newsy.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly TokenManagement _tokenManagement;
        private IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        public AuthenticationService(IOptions<TokenManagement> tokenManagement, IMediator mediator, UserManager<AppUser> userManager)
        {
            _tokenManagement = tokenManagement.Value;
            _userManager = userManager;
            _mediator = mediator;
        }
        public async Task<AppUser> AuthenticateUserWithUsernameAndPassword(string username, string password)
        {
            AppUser userDetail = await GetUserByUsernameWithAllLoginChecksAsync(username);

            var result = await CheckPasswordForUsernameAsync(username, password);
            if (result != SignInResult.Success)
                throw new LoginFailedException("UserDetail", username);

            //if (expiryDays > 0 && passwordExpirationDateTime < DateTime.Now)
            //{
            //    string token = await _userManager.GeneratePasswordResetTokenAsync(userDetail);
            //    if (!string.IsNullOrEmpty(token))
            //    {
            //        token = Uri.EscapeDataString(token);
            //    }
            //    string expiredPassRedirectUrl = $"{_emailManagement.SiteBaseUrl}reset?token={token}&username={userDetail.UserName}&type=expired";
            //    throw new PasswordExpiredException(expiredPassRedirectUrl);
            //}

            return userDetail;
        }

        private async Task<AppUser> GetUserByUsernameWithAllLoginChecksAsync(string username)
        {
            AppUser userDetail = await GetUserDetailByUsernameAsync(username);

            if (userDetail == null)
            {
                throw new UserNotFoundException("AppUser", username);
            }
            else if (!userDetail.EmailConfirmed)
            {
                throw new NotConfirmedException("AppUser", username);
            }
            else if (!userDetail.Active)
            {
                throw new NotActivatedException("AppUser", username);
            }
            else if (!userDetail.Enabled)
            {
                throw new DisabledException("AppUser", username);
            }
            else if (userDetail.LockoutEnd.HasValue && userDetail.LockoutEnd.Value > DateTime.Now)
            {
                throw new UserLockedOutException("AppUser", username);
            }

            return userDetail;
        }

        public async Task<AppUser> GetUserDetailByUsernameAsync(string username)
        {
            var query = new GetUserByUsernameRequest() { Username = username };

            GetUserByUsernameViewModel t = await _mediator.Send(query);

            return t.Data?.FirstOrDefault();
        }

        private async Task<SignInResult> CheckPasswordForUsernameAsync(string username, string password)
        {
            var query = new CheckPasswordForUsernameRequest() { Username = username, Password = password };

            CheckPasswordForUsernameViewModel t = await _mediator.Send(query);

            return t.SignInResult;
        }

        public async Task<string> GenerateTokenAsync(AppUser appUser, string impersonatedByUsername = "", string impersonatedByUserFullName = "")
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenExpires = DateTime.UtcNow.AddMinutes(_tokenManagement.AccessExpiration);
            var expires = DateTime.UtcNow.AddMinutes(_tokenManagement.AccessExpiration);
            var expiresOffset = new DateTimeOffset(expires);
            var expiresUnixDateTime = expiresOffset.ToUnixTimeSeconds();

            var claims = new List<Claim>()
            {
                new Claim("Username", appUser.UserName),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim("Created", DateTime.UtcNow.ToString()),
                new Claim("UserId", appUser.Id.ToString()),
                new Claim("Expires", expiresUnixDateTime.ToString())
            };

            //get roles and claims
            

            var jwtToken = new JwtSecurityToken(
                    _tokenManagement.Issuer,
                    _tokenManagement.Audience,
                    claims,
                    expires: tokenExpires,
                    signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;

        }

        public string GenerateRefreshToken(string username)
        {
            throw new NotImplementedException();
        }
    }
}
