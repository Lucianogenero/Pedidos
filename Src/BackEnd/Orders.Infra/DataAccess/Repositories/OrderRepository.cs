using Orders.Domain.Entities;
using Orders.Domain.Repositories.Order;

namespace Orders.Infra.DataAccess.Repositories
{
    public class OrderRepository : IOrderWriteOnlyRepository
    {
        private readonly OrDbContext _dbContext;

        public OrderRepository(OrDbContext dbContext) => _dbContext = dbContext;
        public async Task New(Order order) 
        {
            await _dbContext.Order.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        } 
        

    }
}
