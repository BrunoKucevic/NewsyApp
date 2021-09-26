using ExpressMapper.Extensions;
using MediatR;
using Newsy.Domain.Interfaces;
using Newsy.Domain.ViewModels.Users;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newsy.Application.Shared.Extensions;
using Newsy.Application.Shared.Interfaces;

namespace Newsy.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersViewModel>
    {
        private readonly INewsyDbContext _context;
        public GetAllUsersHandler(INewsyDbContext context)
        {
            _context = context;
        }
        public async Task<GetAllUsersViewModel> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var res = new GetAllUsersViewModel();

            var query =
                 _context.AppUsers
                .AsNoTracking()
                .OrderBy(x => x.LastName)
                .Include(r => r.UserRoles)
                    .ThenInclude(s => s.Role)
                .Where(u => !u.Archived);

            query = query.PaginateQuery(request.PageSize, request.CurrentPage, res);

            var users = await query.Select(y => y.Map(new AllUsersViewModel()))
                .ToListAsync(cancellationToken);

            res.Data.AddRange(users);

            return res;
        }
    }
}
