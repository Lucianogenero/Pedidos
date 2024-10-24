namespace Orders.Domain.Entities
{
    public class Order
    {
        public Order() 
        {
            Itens = new List<Item>();
        }
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsFinished { get; set; } = false;
        public List<Item> Itens { get; set; }  
    }
}
/*
        public long Id { get; set; }
        public bool IsFinished { get; set; } = false;
        public List<Item> itens { get; set; }
    }

    public partial class Item()
    {
        public string Name { get; set; }
        public int Quantidade { get; set; }
    }
 */