using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.Services
{
    public interface IAuthenticateService
    {
        Task<AppUser> AuthenticateUserWithUsernameAndPassword(string username, string password);
        Task<AppUser> GetUserDetailByUsernameAsync(string username);
        Task<string> GenerateTokenAsync(AppUser userDetail, string impersonatedByUsername = "", string impersonatedByUserFullName = "");

        string GenerateRefreshToken(string username);
    }
}
