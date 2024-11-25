using CargaDwhVenta.Dato.Contexts;
using CargaDwhVenta.Dato.Interfaces;
using CargaDwhVenta.Dato.Services;
using Microsoft.EntityFrameworkCore;

namespace LoadDWVentas.WorkerService
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => {

                services.AddDbContextPool<BDSalesContext>(options =>
                                                          options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbNorwind")));

                services.AddDbContextPool<DwhVentasContext>(options =>
                                                          options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbSales")));


                services.AddScoped<IDimProductCategoryService, DimProductCategoryService>();

                services.AddHostedService<Worker>();
            });
    }
}