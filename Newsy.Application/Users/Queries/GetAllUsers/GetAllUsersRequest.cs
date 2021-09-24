using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<GetAllUsersViewModel>
    {
    }
}
