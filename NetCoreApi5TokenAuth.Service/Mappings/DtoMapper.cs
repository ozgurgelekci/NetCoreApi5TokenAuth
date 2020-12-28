using AutoMapper;
using NetCoreApi5TokenAuth.Core.DTOs;
using NetCoreApi5TokenAuth.Core.Entities.Concrete;

namespace NetCoreApi5TokenAuth.Service.Mappings
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ContentDto, Content>().ReverseMap();

            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
