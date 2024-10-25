namespace Orders.Comunication.Request
{
    public class RequestOrderJson 
    {
        public long Id { get; set; }
        //public bool IsFinished { get; set; } = false;
        public IList<RequestItensJson> Itens { get; set; } = [];
    }
}
