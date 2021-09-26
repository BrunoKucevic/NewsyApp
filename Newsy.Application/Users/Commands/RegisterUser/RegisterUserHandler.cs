using MediatR;
using Microsoft.AspNetCore.Identity;
using Newsy.Domain;
using Microsoft.EntityFrameworkCore;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Users.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserViewModel>
    {
        private readonly INewsyDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public RegisterUserHandler(INewsyDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<RegisterUserViewModel> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    //Guid roleId = _context.Roles.First(r => r.Name == RolesConsts.RegularUser).Id;
                    Guid userId = Guid.NewGuid();

                    PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();

                    AppUser user = new AppUser()
                    {
                        Id = userId,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        UserName = request.Email,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        NormalizedUserName = request.Email.ToUpper(),
                        NormalizedEmail = request.Email.ToUpper(),
                        PasswordHash = hasher.HashPassword(null, request.Password),
                        CreationDate = DateTime.Now
                    };

                    _context.AppUsers.Add(user);
                    _context.UserRoles.Add(new AppUserRole() { RoleId = request.RoleId, UserId = userId });
                    await _context.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);

                    return new RegisterUserViewModel()
                    {
                        UserId = userId
                    };
                }
                catch
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }
    }
}
