using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Commands.RegisterUser
{
    public class RegisterUserRequest : IRequest<RegisterUserViewModel>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
