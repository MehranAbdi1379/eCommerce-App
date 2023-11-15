using eCommerce.Domain.Models;
using eCommerce.Domain.Repositories;
using eCommerce.Repository.Authentication;
using eCommerce.Repository.Authentication.SeedData;
using eCommerce.Repository.Main;
using eCommerce.Repository.Main.DataBase;
using eCommerce.Repository.Main.SeedData;
using eCommerce.Service;
using eCommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(MediatREntryPointClass).Assembly));
        }

        public static void AddDIForRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICategoryRepository, CategoryRespository>();
        }

        public static void AddAuthenticationAndAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
            //builder.AddAuthorization();

        }

        public static void AddAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(opt =>
            opt.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build());
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
            services.AddIdentity<ApiUser, IdentityRole>(o =>
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

        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
        }

        public static void SeedCategoryData(this IServiceCollection service)
        {
            using var scope = service.BuildServiceProvider().CreateScope();
            var eCommerceDBContext = scope.ServiceProvider.GetService<eCommerceDBContext>();
            var categorySeedData = new CategorySeedData(eCommerceDBContext);
            if (eCommerceDBContext.Categories.Count() == 0)
                categorySeedData.SeedData();
        }
        public static async Task SeedUserRoleData(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            var userRoleSeedData = new RoleSeedData(roleManager);
            if (roleManager.Roles.Count() == 0)
                await userRoleSeedData.SeedData();
        }

        public static async Task SeedUserData(this IServiceCollection service)
        {
            using var scope = service.BuildServiceProvider().CreateScope();
            var userManager = scope.ServiceProvider.GetService<UserManager<ApiUser>>();
            var userSeedData = new UserSeedData(userManager);
            if (userManager.Users.Count() == 0)
                await userSeedData.SeedData();
        }

    }
}
