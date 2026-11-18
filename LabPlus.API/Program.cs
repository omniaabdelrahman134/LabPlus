using LabPlus.Infrastructure.Identity;
using LabPlus.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LabPlus.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // ===== Database =====
            builder.Services.AddDbContext<AppDbContext>(o =>
                o.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                 .UseSnakeCaseNamingConvention());

            // ===== Identity =====
            builder.Services
                .AddIdentityCore<ApplicationUser>(o =>
                {
                    o.Password.RequiredLength = 8;
                    o.User.RequireUniqueEmail = true;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}