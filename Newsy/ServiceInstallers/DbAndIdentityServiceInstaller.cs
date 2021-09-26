using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsy.Domain.Context;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using Newsy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.ServiceInstallers
{
    public class DbAndIdentityServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings - used in  by UserManager in ResetPasswordCommand
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                //used by signInManager
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 15, 0);
            });

            services.AddDbContext<NewsyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("newsy"));
            });

            services.AddIdentity<AppUser, Role>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<NewsyDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<INewsyDbContext, NewsyDbContext>();
        }
    }
}
