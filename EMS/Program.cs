using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EMS.Data;
using EMS.Core.IRepo;
using EMS.Services.IServices;
using EMS.Services.Services;
using EMS.Core.Repo;

namespace EMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //get connection string
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<EmsDbContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EmsDbContext>();
            builder.Services.AddTransient<IAccountRepo, AccountRepo>();
            builder.Services.AddTransient<IAccountServices, AccountServices>();
            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();


        }
    }
}