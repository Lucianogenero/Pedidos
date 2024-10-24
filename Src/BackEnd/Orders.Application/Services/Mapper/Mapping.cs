using AutoMapper;
using Orders.Comunication.Request;

namespace Orders.Application.Services.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestAddNewOrderJson, Domain.Entities.Order>()
                      .ForMember(ord => ord.Id, opt => opt.Ignore())
                      .ForMember(ord => ord.IsFinished, opt => opt.Ignore())
                      .ForMember(ord => ord.CreatedOn, opt => opt.Ignore());
        }
    }

}
