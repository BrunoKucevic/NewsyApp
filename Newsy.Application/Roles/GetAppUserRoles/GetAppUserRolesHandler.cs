using MediatR;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Newsy.Application.Roles.GetAppUserRoles
{
    public class GetAppUserRolesHandler : IRequestHandler<GetAppUserRolesRequest, GetAppUserRolesViewModel>
    {
        private readonly INewsyDbContext _context;
        public GetAppUserRolesHandler(INewsyDbContext context)
        {
            _context = context;
        }
        public async Task<GetAppUserRolesViewModel> Handle(GetAppUserRolesRequest request, CancellationToken cancellationToken)
        {
            var res = new GetAppUserRolesViewModel();

            var userRoles = await _context.UserRoles
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .Include(x => x.Role)
                .Select(r => new Role() { Name = r.Role.Name, Id = r.RoleId })
                .ToListAsync(cancellationToken);

            res.Data.AddRange(userRoles);

            return res;
        }
    }
}
