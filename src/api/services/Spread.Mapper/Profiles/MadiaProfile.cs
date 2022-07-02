using AutoMapper;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Media;

namespace Spread.Mapper.Profiles
{
    internal class MadiaProfile : Profile
    {
        public MadiaProfile()
        {
            CreateMap<Post, PostListDto>()
                    .ForMember(x => x.OwnerId, c => c.MapFrom(f => f.UserId))
                    .ForMember(x => x.OwnerName, c => c.MapFrom(f => f.User.FullName))
                    .ForMember(x => x.PublishDate, c => c.MapFrom(f => f.CreatedAt))
                    .ForMember(x => x.CommentCount, c => c.MapFrom(f => f.Comments.Count))
                    .ForMember(x => x.FileName, c => c.MapFrom(f => f.Document.FileName))
                    .ForMember(x => x.LikeCount, c => c.MapFrom(f => f.Likes.Count));
        }
    }
}