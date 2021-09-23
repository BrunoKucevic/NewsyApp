using MediatR;
using Newsy.Domain.Interfaces;
using Newsy.Domain.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpressMapper;
using ExpressMapper.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Newsy.Application.Claims
{
    public class GetClaimsForAppUserHandler : IRequestHandler<GetClaimsForAppUserRequest, GetClaimsForAppUserViewModel>
    {
        private readonly INewsyDbContext _context;
        public GetClaimsForAppUserHandler(INewsyDbContext context)
        {
            _context = context;
        }
        public async Task<GetClaimsForAppUserViewModel> Handle(GetClaimsForAppUserRequest request, CancellationToken cancellationToken)
        {
            var ret = new GetClaimsForAppUserViewModel();

            var roleClaims =
                await _context
                    .RoleClaims
                    .Where(rc => request.RoleIds.Contains(rc.RoleId))
                    .Select(rc => rc.Map(new UserRoleClaimsViewModel()))
                    .ToListAsync(cancellationToken);

            var userClaims =
                 await _context
                    .UserClaims
                    .Where(uc => uc.UserId == request.UserId)
                    .Select(rc => rc.Map(new UserRoleClaimsViewModel()))
                    .ToListAsync(cancellationToken);

            //merge into one list using dictionary. UserClaims will overwrite roleClaims if types are same.
            var dict = roleClaims.ToDictionary(p => p.ClaimType);
            foreach (var claim in userClaims)
            {
                dict[claim.ClaimType] = claim;
            }

            ret.Data.AddRange(dict.Values.ToList());

            return ret;
        }
    }
}
