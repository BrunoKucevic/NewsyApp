using MediatR;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Users.Commands.ActivateUser
{
    public class ActivateUserHandler : IRequestHandler<ActivateUserRequest, ActivateUserViewModel>
    {
        private readonly INewsyDbContext _context;
        public ActivateUserHandler(INewsyDbContext context)
        {
            _context = context;
        }
        public async Task<ActivateUserViewModel> Handle(ActivateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _context.AppUsers.First(x => x.Id == request.UserId);

            user.Active = request.Activate;

            if (!request.Activate)
            {
                user.Archived = true;
                user.ArchivingDate = DateTime.Now;
            }
            await _context.SaveChangesAsync(cancellationToken);

            return new ActivateUserViewModel() { UserId = user.Id };
        }
    }
}
