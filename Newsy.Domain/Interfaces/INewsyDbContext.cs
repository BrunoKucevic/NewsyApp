using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsy.Domain.Interfaces
{
    public interface INewsyDbContext
    {
        DatabaseFacade Database { get; }

        DbSet<AppUser> AppUsers { get; set; }
        DbSet<AppUserClaim> UserClaims { get; set; }
        DbSet<AppUserRole> UserRoles { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<RoleClaim> RoleClaims { get; set; }
    }
}
