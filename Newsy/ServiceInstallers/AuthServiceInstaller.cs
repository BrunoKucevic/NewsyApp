using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newsy.Interfaces;
using Newsy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleR.WebUI.Models;

namespace Newsy.ServiceInstallers
{
    public class AuthServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IAuthenticateService, AuthenticationService>();

            //TokenManagement token = configuration.GetSection("tokenManagement").Get<TokenManagement>();

            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = token.Issuer,
            //        ValidateAudience = true,
            //        ValidAudience = token.Audience,
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret))
            //    };
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Admin", policy => { policy.RequireClaim("Admin"); policy.RequireRole("Admin"); });
            //    options.AddPolicy("Author", policy => policy.RequireClaim("Author"));
            //    options.AddPolicy("RegularUser", policy => policy.RequireClaim("RegularUser"));
            //});
        }
    }
}
