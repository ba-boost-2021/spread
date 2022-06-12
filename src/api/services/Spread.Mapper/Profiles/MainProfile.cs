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
        }
    }
}