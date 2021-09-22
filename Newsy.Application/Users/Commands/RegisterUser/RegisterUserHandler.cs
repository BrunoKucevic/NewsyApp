using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserViewModel>
    {
        public Task<RegisterUserViewModel> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
