using ExpressMapper.Extensions;
using MediatR;
using Newsy.Domain.Interfaces;
using Newsy.Domain.ViewModels.Roles;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;

namespace Newsy.Application.Roles.Queries.GetAllRoles
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesViewModel>
    {
        private readonly INewsyDbContext _context;
        public GetAllRolesHandler(INewsyDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task<GetAllRolesViewModel> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            var res = new GetAllRolesViewModel();
            var roles = await _context.Roles
                .AsNoTracking()
                .OrderBy(y => y.Name)
                .Select(x => x.Map(new RolesViewModel()))
                .ToListAsync(cancellationToken);

            res.Data.AddRange(roles);

            return res;
        }
    }
}
