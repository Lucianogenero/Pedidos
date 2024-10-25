using System.Net;

namespace Orders.Exceptions.ExceptionBase
{
    public abstract class OrderExceptions : SystemException
    {
        protected OrderExceptions(string message): base(message) { }

        public abstract IList<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
