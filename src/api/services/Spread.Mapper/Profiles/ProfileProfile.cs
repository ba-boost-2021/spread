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
                //.ForMember(m => m.UserName, f => f.MapFrom(s => s.UserName)); --> aslında olan ama default olarak yapılan
            CreateMap<RegisterUserRequestDto, User>();
            CreateMap<Follower, FollowerInfoDto>()
                .ForMember(m => m.UserName, f => f.MapFrom(s => s.FollowingUser.UserName))
                .ForMember(m => m.Name, f => f.MapFrom(s => s.FollowingUser.FullName));
        }
    }
}