using AutoMapper;
using SFSAdv.Domain.Aggregates.OrderAggregate.Entities;
using SFSAdv.Domain.Aggregates.OrderAggregate.ReadModels;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.ProductAggregate.ReadModels;
using SFSAdv.Domain.Aggregates.UserAggregate.Entities;
using SFSAdv.Domain.Aggregates.UserAggregate.ReadModels;

namespace SFSAdv.Application.Mapping;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Product, ProductReadModel>()
                       .ForMember(dest => dest.FinalPrice, opt => opt.Ignore());
        CreateMap<User, UserReadModel>().ReverseMap();
        CreateMap<Order, OrderReadModel>().ReverseMap();
    }
}
