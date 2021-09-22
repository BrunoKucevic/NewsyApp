using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Application.Users.Commands.RegisterUser
{
    public class RegisterUserRequest : IRequest<RegisterUserViewModel>
    {
    }
}
