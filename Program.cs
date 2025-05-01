using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using MVC_CRUD.Repositories.Contract;
using MVC_CRUD.Repositories.Implementation;
using MVC_CRUD.Services.Contract;
using MVC_CRUD.Services.Implementation;

namespace MVC_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Data Source=THAWTHONA\\SQLEXPRESS;Initial Catalog=MVC_CRUD;Integrated Security=True;TrustServerCertificate=True;"));

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
