using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newsy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        DbSet<Article> Articles { get; set; }
        DbSet<AppUserArticle> AppUserArticles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
