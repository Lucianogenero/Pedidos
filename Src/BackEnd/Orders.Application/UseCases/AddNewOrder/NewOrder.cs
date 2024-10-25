using Orders.Application.Services.Mapper;
using Orders.Application.UseCases.AddNewOrder;
using Orders.Comunication.Request;
using Orders.Comunication.Response;
using Orders.Domain.Repositories;
using Orders.Domain.Repositories.Order;
using Orders.Exceptions.ExceptionBase;

namespace Orders.Application.UseCases.Order
{
    public class NewOrder : INewOrder //aplication
    {
        private readonly IUnitOfWork _unitiOfWork;
        private readonly IOrderWriteOnlyRepository _writeOnlyRepository; //domain
       
        public NewOrder(IUnitOfWork unitOfWork, IOrderWriteOnlyRepository writeOnlyRepository)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _unitiOfWork = unitOfWork;
        }

        async Task<ResposeAddedNewOrderJson> INewOrder.Execute(RequestOrderJson request)
        {
            Validate(request);

            var autoMapper = new AutoMapper.MapperConfiguration(option =>
            {
                option.AddProfile(new Mapping());
            }).CreateMapper();

            var order = autoMapper.Map<Domain.Entities.Order>(request);
            
            await _writeOnlyRepository.New(order);
            await _unitiOfWork.Commit();

            //return autoMapper.Map<ResposeAddedNewOrderJson>(order);

            return new ResposeAddedNewOrderJson()
            {
                OrderReturns = $"Pedido finalizado."
            };
        }

        private void Validate(RequestOrderJson request)
        {
            NewOrderValidation validator = new NewOrderValidation();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ErrorsOnValidationExceptions(result.Errors.Select(err => err.ErrorMessage).Distinct().ToList());
            }
        }

    }
}
