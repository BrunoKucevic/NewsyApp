using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Commands.CheckPassword
{
    public class CheckPasswordForUsernameViewModel
    {
        public Guid UserId { get; set; }
        public SignInResult SignInResult { get; set; }
    }
}
