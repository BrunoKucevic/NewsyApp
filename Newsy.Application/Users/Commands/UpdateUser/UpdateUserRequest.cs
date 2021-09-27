using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Commands.UpdateCurrentUser
{
    public class UpdateUserRequest : IRequest<UpdateUserViewModel>
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? RoleId { get; set; }
    }
}
