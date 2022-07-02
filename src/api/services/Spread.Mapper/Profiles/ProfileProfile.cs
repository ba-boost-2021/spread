using AutoMapper;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Profile;

namespace Spread.Mapper.Profiles
{
    internal class ProfileProfile : Profile
    {
        public ProfileProfile()
        {
            CreateMap<User, UserListDto>();
            CreateMap<RegisterUserRequestDto, User>();
            CreateMap<User, FollowerListDto>();             //Burada da User yerine Follower kullanmak gerekmiyor muydu ?
            CreateMap<User, FollowRequestListDto>();
        }
    }
}