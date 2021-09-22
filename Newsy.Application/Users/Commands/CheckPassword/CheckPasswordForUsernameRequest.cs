using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Commands.CheckPassword
{
    public class CheckPasswordForUsernameRequest : IRequest<CheckPasswordForUsernameViewModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
