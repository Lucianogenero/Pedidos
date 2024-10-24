using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;

namespace Orders.Infra.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions option): base(option) {}

        DbSet<Order> Orders {  get; set; }
        DbSet<Item> Itens {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Orders.Infra.DataAccess.OrderDbContext).Assembly);
        }

    }
}
