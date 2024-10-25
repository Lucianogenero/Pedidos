namespace Orders.Comunication.Request
{
    public class RequestItensJson
    {
        public long Id { get; set; }
        public long OrderId { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int Quantidade { get; set; }
    }
}
