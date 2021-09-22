using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameRequest : IRequest<GetUserByUsernameViewModel>
    {
        public string Username { get; set; }
    }
}
