namespace Orders.Domain.Repositories.Order
{
    public interface IOrderWriteOnlyRepository
    {
        public Task New(Entities.Order order);
    }
}
