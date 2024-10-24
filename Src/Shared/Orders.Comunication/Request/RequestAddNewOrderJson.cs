namespace Orders.Comunication.Request
{
    public partial class RequestAddNewOrderJson
    {
        public RequestAddNewOrderJson() => Itens = new List<Item>();
        public long Id { get; set; }
        public bool IsFinished { get; set; } = false;
        public List<Item> Itens { get; set; }
    }

    public partial class Item()
    {
        public string Name { get; set; }
        public int Quantidade { get; set; }
    }
}
