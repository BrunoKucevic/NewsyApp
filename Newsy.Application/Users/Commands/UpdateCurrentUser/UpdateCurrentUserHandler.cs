using MediatR;
using Newsy.Application.Shared.Interfaces;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Users.Commands.UpdateCurrentUser
{
    public class UpdateCurrentUserHandler : IRequestHandler<UpdateCurrentUserRequest, UpdateCurrentUserViewModel>
    {
        private readonly INewsyDbContext _context;
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public UpdateCurrentUserHandler(INewsyDbContext context, ICurrentUserAccessor currentUserAccessor)
        {
            _context = context;
            _currentUserAccessor = currentUserAccessor;
        }
        public async Task<UpdateCurrentUserViewModel> Handle(UpdateCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.Id == _currentUserAccessor.GetUserId());

            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateCurrentUserViewModel()
            {
                UserId = user.Id
            };
        }
    }
}
