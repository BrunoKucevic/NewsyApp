using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Commands.ActivateUser
{
    public class ActivateUserRequest : IRequest<ActivateUserViewModel>
    {
        public Guid UserId { get; set; }
        public bool Activate { get; set; }
    }
}
