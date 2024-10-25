using Orders.Domain.Repositories;

namespace Orders.Infra.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrDbContext _dbContext;

        public UnitOfWork(OrDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
