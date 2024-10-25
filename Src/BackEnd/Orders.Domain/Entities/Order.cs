namespace Orders.Domain.Entities
{
    public class Order : EntityBase
    {
        public Order() => IsFinished = false;
        public bool IsFinished { get; set; }
        public IList<Item> Itens { get; set; } = [];
    }
}