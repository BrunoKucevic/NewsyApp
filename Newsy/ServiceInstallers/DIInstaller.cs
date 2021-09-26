using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newsy.Application.Shared.Interfaces;
using Newsy.Domain.Entities;
using Newsy.Interfaces;
using Newsy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newsy.ServiceInstallers
{
    public class DIInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICurrentUserAccessor, CurrentUserAccessor>();
            services.AddTransient<UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>>();
            services.AddScoped<IAuthenticateService, AuthenticationService>();
        }
    }
}
