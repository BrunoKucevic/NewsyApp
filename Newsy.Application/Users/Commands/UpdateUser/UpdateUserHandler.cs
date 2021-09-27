using MediatR;
using Newsy.Application.Shared.Interfaces;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Users.Commands.UpdateCurrentUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserViewModel>
    {
        private readonly INewsyDbContext _context;

        public UpdateUserHandler(INewsyDbContext context)
        {
            _context = context;
        }
        public async Task<UpdateUserViewModel> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = _context.AppUsers.FirstOrDefault(x => x.Id == request.UserId);

                    user.Email = request.Email;
                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                    user.PhoneNumber = request.PhoneNumber;

                    if (request.RoleId.HasValue)
                    {
                        UpdateUserRole(request);
                    }

                    await _context.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);

                    return new UpdateUserViewModel()
                    {
                        UserId = user.Id
                    };
                }
                catch 
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }

        private void UpdateUserRole(UpdateUserRequest request)
        {
            AppUserRole userRole = null;
            userRole = _context.UserRoles.FirstOrDefault(r => r.UserId == request.UserId);
            _context.UserRoles.RemoveRange(userRole);
            _context.UserRoles.Add(new AppUserRole() { UserId = request.UserId, RoleId = request.RoleId.Value });
        }
    }
}
