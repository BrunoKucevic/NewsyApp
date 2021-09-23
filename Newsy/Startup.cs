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
using Newsy.Application.Users.Commands.RegisterUser;
using Newsy.Domain.Context;
using Newsy.Domain.Entities;
using Newsy.Domain.Interfaces;
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
        private TokenValidationParameters tokenValidationParameters;
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
                options.UseSqlServer(Configuration.GetConnectionString("newsy"));
            });


            services.AddIdentity<AppUser, Role>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<NewsyDbContext>()
                .AddDefaultTokenProviders();

            Application.AppInit.Initialize();

            //// Add MediatR
            services.AddMediatR(typeof(RegisterUserHandler).GetTypeInfo().Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestCurrentCultureBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestStringTrimmingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));

            services.AddTransient<ICurrentUserAccessor, CurrentUserAccessor>();
            services.AddTransient<UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>>();

            services.AddTransient<INewsyDbContext, NewsyDbContext>();
            //services.AddTransient<PasswordHasher<UserDetail>>();
            services.AddScoped<IAuthenticateService, AuthenticationService>();

            TokenManagement token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            //tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuerSigningKey = true,
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
            //    ValidIssuer = token.Issuer,
            //    ValidAudience = token.Audience,
            //    ValidateIssuer = false,
            //    ValidateAudience = false,
            //    ValidateLifetime = true,
            //    RequireExpirationTime = true,
            //    ClockSkew = new TimeSpan(0)
            //};

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
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)))
            //    };
            //};
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = tokenValidationParameters;
            //});

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                //c.EnableAnnotations();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Newsy API", Version = "v1", Description = "This is made for a Newsy Web API" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
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
