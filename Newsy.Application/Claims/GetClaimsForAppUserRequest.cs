using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Claims
{
    public class GetClaimsForAppUserRequest : IRequest<GetClaimsForAppUserViewModel>
    {
        public Guid UserId { get; set; }
        public List<Guid> RoleIds { get; set; }
    }
}
