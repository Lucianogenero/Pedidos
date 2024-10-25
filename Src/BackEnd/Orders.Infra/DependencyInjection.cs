using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Domain.Repositories;
using Orders.Domain.Repositories.Order;
using Orders.Infra.DataAccess;
using Orders.Infra.DataAccess.Repositories;
using System.Reflection;

namespace Orders.Infra
{
    public static class DependencyInjection
    {
        private static string _connectionString = "";

        public static void AddInfraStructure(this IServiceCollection services, IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            AddRepositories(services);

            AddDbContext(services);
            AddFluentMigrator(services);
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderWriteOnlyRepository, OrderRepository>();
        }

        public static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<OrDbContext>(dbContextOption =>
            {
                dbContextOption.UseSqlServer(_connectionString);
            });
        }

        private static void AddFluentMigrator(IServiceCollection services)
        {
            services.AddFluentMigratorCore().ConfigureRunner(options =>
            {
                options
                .AddSqlServer()
                .WithGlobalConnectionString(_connectionString)
                .ScanIn(Assembly.Load("Orders.Infra")).For.All();
            });
        }
    }
}
