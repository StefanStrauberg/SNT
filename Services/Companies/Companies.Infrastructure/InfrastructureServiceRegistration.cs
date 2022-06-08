using Companies.Application.Contracts;
using Companies.Infrastructure.Configurations;
using Companies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Companies.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase(configuration.GetConnectionString("DatabaseName")));
            services.AddScoped((typeof(IGenericRepository<>)), (typeof(GenericRepository<>)));
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }
}
