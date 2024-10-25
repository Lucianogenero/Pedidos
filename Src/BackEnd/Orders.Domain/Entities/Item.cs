namespace Orders.Domain.Entities
{
    public class Item : EntityBase
    {
        public long OrderId { get; set; } = 1;
        public string Name { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }
}
