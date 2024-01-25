using ASP.Web_API.Configuration;
using ASP.Web_API.Contracts;
using AutoMapper;

namespace ASP.Web_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));
        }
    }
}
