using Asp_Net_Core_Mvc_Store.Data;
using Asp_Net_Core_Mvc_Store.Services;
using Asp_Net_Core_Mvc_Store.Services.Implementations;

namespace Asp_Net_Core_Mvc_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
