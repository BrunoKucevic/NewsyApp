using MediatR;
using Microsoft.AspNetCore.Identity;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Users.Commands.CheckPassword
{
    public class CheckPasswordForUsernameHandler : IRequestHandler<CheckPasswordForUsernameRequest, CheckPasswordForUsernameViewModel>
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

    public CheckPasswordForUsernameHandler(IMediator mediator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _mediator = mediator;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<CheckPasswordForUsernameViewModel> Handle(CheckPasswordForUsernameRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByEmailAsync(request.Username);
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

        return new CheckPasswordForUsernameViewModel
        {
            UserId = user.Id,
            SignInResult = result
        };
    }
}
}
