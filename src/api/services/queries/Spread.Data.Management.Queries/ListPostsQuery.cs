using AutoMapper;
using MediatR;
using Spread.Common;
using Spread.Common.Enums;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Data.Requests.Contracts;
using Spread.Entities.Media;
using Spread.Entities.Profile;
using Spread.FileStorage.Abstractions;
using System.Linq.Expressions;

namespace Spread.Data.Management.Queries;

internal class ListPostsQuery : IRequestHandler<ListPostsRequest, List<PostListDto>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IClaims claims;
    private readonly IFileStorageService fileStorageService;

    public ListPostsQuery(IUnitOfWork unitOfWork, IClaims claims, IFileStorageService fileStorageService)
    {
        this.unitOfWork = unitOfWork;
        this.claims = claims;
        this.fileStorageService = fileStorageService;
    }

    public async Task<List<PostListDto>> Handle(ListPostsRequest request, CancellationToken cancellationToken)
    {
        var postRepository = unitOfWork.GetRepository<Post>();
        var followerRepository = unitOfWork.GetRepository<Follower>();
        var followers = await followerRepository.GetAll(x => !x.IsDeleted && x.IsActive && x.UserId == claims.CurrentUser.Id && x.IsApproved, cancellationToken);
        var followerIds = followers.Select(x => x.FollowingUserId).ToList();
        followerIds.Add(claims.CurrentUser.Id);
        Expression<Func<Post, bool>> predicate = f => f.IsActive && !f.IsDeleted && followerIds.Contains(f.UserId);
        var result = await postRepository.GetAll<PostListDto>(predicate, cancellationToken);
        result.ForEach(post =>
        {
            post.FileUrl = fileStorageService.GetFileUrl($"{post.OwnerId}/{UserFolder.Posts.ToString().ToLower()}/{post.FileName}", StorageType.Images);
        });
        return result.OrderByDescending(f=>f.PublishDate).ToList();
        //TODO: Order DESC Repository'e eklenmeli
    }
}