using eCommerce.Repository.Authentication;
using eCommerce.Repository.Main.DataBase;
using eCommerce.Service;
using eCommerce.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure;
using NETCore.MailKit.Infrastructure.Internal;
using System.Text;

namespace eCommerce.API.Extensions
{
    public static class Extensions
    {
        public static void AddDIForServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
        }

        public static void AddAuthenticationAndAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
        }

        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                var frontendURL1 = builder.Configuration.GetValue<string>("frontend_url1");
                var frontendURL2 = builder.Configuration.GetValue<string>("frontend_url2");

                options.AddDefaultPolicy(builder =>
                builder.WithOrigins(frontendURL1).AllowAnyMethod().AllowAnyHeader());
                options.AddDefaultPolicy(builder =>
                builder.WithOrigins(frontendURL2).AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void AddDataBaseContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<eCommerceAuthDbContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("AuthDBSQLServer")));
            builder.Services.AddDbContext<eCommerceDBContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("MainDBSQLServer")));
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = true;
                o.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<eCommerceAuthDbContext>()
            .AddDefaultTokenProviders();
        }

        public static void AddEmailService(this WebApplicationBuilder builder)
        {
            var mailKitOptions = builder.Configuration.GetSection("Email").Get<MailKitOptions>();
            builder.Services.AddMailKit(config =>
            {
                config.UseMailKit(mailKitOptions);
            });
        }

        public static void ConfigureJWT(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var secretKey = Environment.GetEnvironmentVariable("KEY");
            service.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new
    SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });

        }
    }
}
