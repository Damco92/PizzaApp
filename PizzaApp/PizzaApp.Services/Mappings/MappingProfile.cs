using AutoMapper;
using PizzaApp.DataAccess.Models;
using PizzaApp.Services.Dtos;

namespace PizzaApp.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pizza, PizzaDto>()
                .ForMember(destination => destination.PizzaSize,
               opts => opts.MapFrom(source => source.PizzaSizeId.ToString()))
                .ForMember(destination => destination.PizzaType,
                opts => opts.MapFrom(source => source.PizzaTypeId.ToString()))
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ForMember(destination => destination.IsDelivered,
                opts => opts.MapFrom(source => source.IsDelivered))
                .ForMember(destination => destination.DateAndTimeSubmited,
                opts => opts.MapFrom(source => source.TimeSubmited))
                .ForMember(destination => destination.CurrentStateType,
                    opts => opts.MapFrom(source => source.StateNavigation.StateTypeId.ToString()))
                .ReverseMap();

            CreateMap<State, StateDto>()
                .ForMember(destination => destination.StateName,
                opts => opts.MapFrom(source => source.Name))
                .ForMember(destination => destination.StateDescription,
                opts => opts.MapFrom(source => source.Description))
                .ForMember(destination => destination.StateType,
                opts => opts.MapFrom(source => source.StateType.Type))
                 .ReverseMap();

            CreateMap<PizzaSize, PizzaSizeDto>()
                .ForMember(destination => destination.PizzaSize,
                opts => opts.MapFrom(source => source.PizzaSizeId.ToString()))
                .ReverseMap();

            CreateMap<PizzaType, PizzaTypeDto>()
                .ForMember(destination => destination.PizzaType,
                opts => opts.MapFrom(source => source.PizzaTypeId.ToString()))
                .ReverseMap();
        }
    }
}
