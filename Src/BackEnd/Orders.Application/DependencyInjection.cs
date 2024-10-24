using Microsoft.Extensions.DependencyInjection;
using Orders.Application.UseCases.AddNewOrder;
using Orders.Application.UseCases.Order;

namespace Orders.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped<INewOrder,NewOrder>();
        }
    }
}
