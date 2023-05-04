using LMS.Repository;
using LMS.Repository.Repositories;
using LMS.Service.Services;
using LMS.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMS.WebApplication {
    public static class DependencyResolver {

        public static void ConfigureRepository(this WebApplicationBuilder builder) {

            var cnnString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (cnnString == null)
                throw new Exception("ConnectionString 'DefaultConnection' not informed on appSettings.");

            builder.Services.AddDbContext<RepositoryContext>(options => options.UseMySQL(cnnString, b => b.MigrationsAssembly("LMS.WebApplication")));

            builder.Services.AddScoped<UserRepository>();

        }

        public static void ConfigureService(this WebApplicationBuilder builder) {

            builder.Services.AddScoped<UserService>();

        }

    }
}
