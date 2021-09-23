using Microsoft.AspNetCore.Http;
using Newsy.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newsy
{
    public class CurrentUserAccessor : ICurrentUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetUserFullName()
        {
            if (_httpContextAccessor?.HttpContext?.User?.Identity == null)
                return string.Empty;

            List<Claim> claims = ((ClaimsIdentity)(_httpContextAccessor?.HttpContext?.User?.Identity)).Claims?.ToList();

            var fullName = claims?.FirstOrDefault(c => c.Type == "FullName")?.Value;

            return fullName;
        }

        public Guid GetUserId()
        {
            if (_httpContextAccessor?.HttpContext?.User?.Identity == null)
                return Guid.Empty;

            List<Claim> claims = ((ClaimsIdentity)(_httpContextAccessor?.HttpContext?.User?.Identity)).Claims?.ToList();

            var userId = claims?.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return string.IsNullOrEmpty(userId) ? Guid.Empty : new Guid(userId);
        }

        public string GetUsername()
        {
            if (_httpContextAccessor?.HttpContext == null)
                return string.Empty;

            List<Claim> claims = ((ClaimsIdentity)(_httpContextAccessor?.HttpContext?.User?.Identity)).Claims?.ToList();

            var userName = claims?.FirstOrDefault(c => c.Type == "Username")?.Value;
            return userName;
        }
    }
}
