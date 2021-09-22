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
using Newsy.Application.Users.Commands.RegisterUser;
using Newsy.Domain.Context;
using Newsy.Domain.Interfaces;
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
        private TokenValidationParameters tokenValidationParameters;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<INewsyDbContext, NewsyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("newsy"));
            });

            // services.AddDefaultIdentity

            //services.AddIdentity<UserDetail, Role>()
            //    .AddRoles<Role>()
            //    .AddEntityFrameworkStores<NewsyDbContext>()
            //    .AddDefaultTokenProviders();

            //// Add MediatR
            services.AddMediatR(typeof(RegisterUserHandler).GetTypeInfo().Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestCurrentCultureBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestStringTrimmingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //if (!_hostingEnvironment.IsDevelopment())
            //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationInsightsCustomBehavior<,>));

            // standard DI
            //services.AddTransient<INotificationService, EmailNotificationService>();
            //services.AddTransient<ICurrentUserAccessor, CurrentUserAccessor>();
            //services.AddTransient<UserManager<UserDetail>>();
            //services.AddTransient<SignInManager<UserDetail>>();
            //if needed ITripleRDbContext can be switched to scoped
            services.AddTransient<INewsyDbContext, NewsyDbContext>();
            //services.AddTransient<PasswordHasher<UserDetail>>();
            //services.AddScoped<IAuthenticateService, AuthenticateService>();

            // 1. Add Authentication Services
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.Authority = "https://dev-23rherum.us.auth0.com/";
            //    options.Audience = "https://newsy.com";
            //});
            TokenManagement token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                ValidIssuer = token.Issuer,
                ValidAudience = token.Audience,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ClockSkew = new TimeSpan(0)
            };
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });

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

            app.UseAuthorization();

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
