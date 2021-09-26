using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newsy.Application.Shared.Interfaces;
using Newsy.Application.Shared.Pipeline;
using Newsy.Application.Users.Commands.RegisterUser;
using Newsy.Domain.Context;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
using Newsy.Interfaces;
using Newsy.ServiceInstallers;
using Newsy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TripleR.WebUI.Models;

namespace Newsy
{
    public class Startup
    {
        //private readonly IServiceProvider _serviceProvider;
        //private TokenValidationParameters tokenValidationParameters;
        public Startup(IConfiguration configuration/*, IServiceProvider serviceProvider*/)
        {
            Configuration = configuration;
            //_serviceProvider = serviceProvider;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));

            services.InstallAllServices(Configuration);

            Application.AppInit.Initialize();

            TokenManagement token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = token.Issuer,
                    ValidateAudience = true,
                    ValidAudience = token.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret))
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => { policy.RequireClaim("Admin"); policy.RequireRole("Admin"); });
                options.AddPolicy("Author", policy => policy.RequireClaim("Author"));
                options.AddPolicy("RegularUser", policy => policy.RequireClaim("RegularUser"));
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStatusCodePages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Newsy API");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
