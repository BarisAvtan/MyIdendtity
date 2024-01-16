using IdendtityCore.Context;
using IdendtityCore.Repositories.Abstractions;
using IdendtityCore.Repositories.Concretes;
using IdendtityCore.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace IdendtityCore.Extensionss
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
