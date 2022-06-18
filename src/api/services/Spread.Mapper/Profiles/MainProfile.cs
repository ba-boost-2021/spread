using AutoMapper;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Main;

namespace Spread.Mapper.Profiles
{
    internal class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<NewLookupRequestDto, LookUp>();
            CreateMap<NewLookupTypeRequestDto, LookupType>();
            CreateMap<NewSystemParameterRequestDto, SystemParameter>();
            CreateMap<LookUp, LookUpDto>()
                    .ForMember(f => f.TypeName, c => c.MapFrom(m => m.Type.Name));
            CreateMap<LookupType, LookupTypeDto>();
            CreateMap<SystemParameter, SystemParameterDto>();
        }
    }
}