using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;

namespace Orders.Infra.DataAccess
{
    public class OrDbContext : DbContext
    {
        public OrDbContext(DbContextOptions option): base(option) {}

        public DbSet<Order> Order {  get; set; }
       //public DbSet<Item> Itens {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrDbContext).Assembly);
        }

    }
}
