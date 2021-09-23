using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Roles.GetAppUserRoles
{
    public class GetAppUserRolesRequest : IRequest<GetAppUserRolesViewModel>
    {
        public Guid UserId { get; set; }
    }
}
