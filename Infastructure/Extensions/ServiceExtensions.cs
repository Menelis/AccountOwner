using Microsoft.Extensions.DependencyInjection;
using Core.Interfaces.Gateways.Repositories;
using Infastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Register Repositoroies on container
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        }
        /// <summary>
        /// Configure Db Context
        /// </summary>
        /// <param name="services"></param>
        /// <param name="databaseName"></param>
        public static void ConfigureDbContext(this IServiceCollection services, string databaseName = "InMemoryDatabase")
        {
            services.AddDbContext<Data.AccountOwnerDbContext>(options => options.UseInMemoryDatabase(databaseName));
        }
    }
}