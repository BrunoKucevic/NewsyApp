using MediatR;
using Newsy.Domain.Context;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
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
        public System.Threading.Tasks.Task<GetUserByUsernameViewModel> Handle(GetUserByUsernameRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
