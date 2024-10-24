namespace Orders.Domain.Entities
{
    public class Item : EntityBase
    {
        public long OrderId { get; set; }
        public string Name { get; set; }
        public int Quantidade { get; set; }
    }
}
