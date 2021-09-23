using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Commands.UpdateCurrentUser
{
    public class UpdateCurrentUserRequest : IRequest<UpdateCurrentUserViewModel>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
