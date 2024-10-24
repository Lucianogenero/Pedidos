using Orders.Application.Services.Mapper;
using Orders.Application.UseCases.AddNewOrder;
using Orders.Comunication.Request;
using Orders.Comunication.Response;
using Orders.Exceptions.ExceptionBase;

namespace Orders.Application.UseCases.Order
{
    public class NewOrder : INewOrder
    {
        async Task<ResposeAddedNewOrderJson> INewOrder.Execute(RequestAddNewOrderJson request)
        {
            Validate(request);

            var autoMapper = new AutoMapper.MapperConfiguration(option =>
            {
                option.AddProfile(new Mapping());
            }).CreateMapper();

            var Order = autoMapper.Map<Domain.Entities.Order>(request);

            await Task.Delay(20);

            return new ResposeAddedNewOrderJson
            {
                OrderReturns = $"Pedido: {request.Id} finalizado.",
            };
        }

        private void Validate(RequestAddNewOrderJson request)
        {
            NewOrderValidation validator = new NewOrderValidation();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ErrorsOnValidationExceptions(result.Errors.Select(err => err.ErrorMessage).ToList()) ;
            }
        }

    }
}
