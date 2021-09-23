using MediatR;
using Newsy.Domain.Context;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;

namespace Newsy.Application.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameRequest, GetUserByUsernameViewModel>
    {
        private readonly INewsyDbContext _context;
        public GetUserByUsernameHandler(INewsyDbContext context)
        {
            _context = context;
        }
        public async System.Threading.Tasks.Task<GetUserByUsernameViewModel> Handle(GetUserByUsernameRequest request, CancellationToken cancellationToken)
        {
            var res = new GetUserByUsernameViewModel();

            var user = await _context.AppUsers.Where(u => u.UserName == request.Username)
                .AsNoTracking().ToListAsync(cancellationToken);

            res.Data.AddRange(user);

            return res;
        }
    }
}
