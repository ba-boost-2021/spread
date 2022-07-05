using AutoMapper;
using MediatR;
using Spread.Common;
using Spread.Common.Enums;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Entities.Main;
using Spread.Entities.Media;
using Spread.FileStorage.Abstractions;

namespace Spread.Data.Management.Commands
{
    internal class NewPostCommand : IRequestHandler<NewPostRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IFileStorageService fileStorageService;
        private readonly IClaims claims;

        public NewPostCommand(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService, IClaims claims)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
            this.claims = claims;
        }

        public async Task<bool> Handle(NewPostRequest request, CancellationToken cancellationToken)
        {
            var documentRepo = unitOfWork.GetRepository<Document>();
            var postRepo = unitOfWork.GetRepository<Post>();

            var stream = request.Data.File.OpenReadStream();
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Data.File.FileName)}";
            var storageResult = await fileStorageService.Upload($"{claims.CurrentUser.Id}/{UserFolder.Posts.ToString().ToLower()}/{fileName}", stream, StorageType.Images, cancellationToken);
            if (!storageResult)
            {
                return false;
            }
            var documentId = Guid.NewGuid();
            var newDocument = new Document
            {
                Id = documentId,
                FileName = fileName,
            };
            var newPost = new Post
            {
                DocumentId = documentId,
                UserId = claims.CurrentUser.Id,
                Content = request.Data.Content,
            };
            postRepo.Insert(newPost);
            documentRepo.Insert(newDocument);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result == 2;
        }
    }
    // images/25874fd78-0000-0000-0000-000000000002/posts/25874fd78-0000-0000-0000-000000000001.png
}