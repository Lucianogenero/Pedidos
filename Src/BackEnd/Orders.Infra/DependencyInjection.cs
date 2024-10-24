using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.Infra.DataAccess;

namespace Orders.Infra
{
    public static class DependencyInjection
    {
        public static void AddInfraStructure(this IServiceCollection services) 
        {
            AddDbContext(services);
        
        }

        public static void AddDbContext(IServiceCollection services)
        {
            var connectionString = "Server=localhost;User Id=sa;Password=123456;Database=DB_Api-1;Trusted_Connection=true;Encrypt=false";

            services.AddDbContext<OrderDbContext>(dbContextOption =>
            {
                dbContextOption.UseSqlServer(connectionString);
            });
        }

        //adicionar repos

    }
}
