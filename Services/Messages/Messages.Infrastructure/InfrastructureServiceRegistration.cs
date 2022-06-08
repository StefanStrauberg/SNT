using Messages.Application.Contracts;
using Messages.Infrastructure.Configurations;
using Messages.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messages.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseInMemoryDatabase(configuration.GetConnectionString("DatabaseName")));
            services.AddScoped((typeof(IGenericRepository<>)), (typeof(GenericRepository<>)));
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return services;
        }
    }
}