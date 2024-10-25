using AutoMapper;
using Orders.Comunication.Request;
using Orders.Comunication.Response;

namespace Orders.Application.Services.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            RequestToDomain();
            DomainToResponse();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestOrderJson, Domain.Entities.Order>()
                      .ForMember(dest => dest.Id, opt => opt.Ignore())
                      //.ForMember(dest => dest.IsFinished, opt => opt.Ignore())
                      .ForMember(dest => dest.Itens, opt => opt.MapFrom(it => it.Itens.Distinct()));

            CreateMap<RequestItensJson, Domain.Entities.Item>()
                      .ForMember(dest => dest.Id, opt => opt.Ignore())
                      //.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
                      .ForMember(dest => dest.OrderId, opt => opt.Ignore());

        }

        private void DomainToResponse()
        {
            CreateMap<Domain.Entities.Order, ResposeAddedNewOrderJson>();            
        }
    }

}
