using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newsy.Domain.Entities;
using Newsy.Domain.EntityConfigurations;
using Newsy.Domain.Interfaces;
using System;
using Audit.EntityFramework;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Newsy.Domain.Context
{
    public partial class NewsyDbContext: AuditIdentityDbContext<AppUser, Role, Guid, AppUserClaim, AppUserRole, AppUserLogin, RoleClaim, AppUserToken>, INewsyDbContext
    {
        public NewsyDbContext(DbContextOptions<NewsyDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual new DbSet<AppUserClaim> UserClaims { get; set; }
        public virtual new DbSet<AppUserRole> UserRoles { get; set; }
        public virtual new DbSet<Role> Roles { get; set; }
        public virtual new DbSet<RoleClaim> RoleClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("newsy");
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserEntityConfiguration());
            builder.ApplyConfiguration(new AppUserRoleEntityConfiguration());
            builder.ApplyConfiguration(new RoleEntityConfiguration());
            builder.ApplyConfiguration(new AppUserLoginConfiguration());
            builder.ApplyConfiguration(new AppUserTokenConfiguration());
        }
    }
}
