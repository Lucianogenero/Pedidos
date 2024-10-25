using Orders.Comunication.Request;
using Orders.Comunication.Response;

namespace Orders.Application.UseCases.AddNewOrder
{
    public interface INewOrder
    {
        public Task<ResposeAddedNewOrderJson> Execute(RequestOrderJson request);
    }
}
