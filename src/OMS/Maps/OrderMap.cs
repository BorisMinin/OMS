using AutoMapper;
using OMS.API.Models.Dtos.OrderDto;
using OMS.Data.Model.Entities;

namespace OMS.Maps
{
    public class OrderMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Order, OrderDtoGet>()
                //.ForMember(x => x.OrderDetails, y => y.MapFrom(z => z.))
                ;
            configuration.CreateMap<OrderDetail, OrderDtoGet>().ReverseMap();
            configuration.CreateMap<Order, OrderDetail>().ReverseMap();
        }
    }
}