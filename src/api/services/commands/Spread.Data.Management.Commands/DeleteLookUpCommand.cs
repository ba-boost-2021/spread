using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Queries;
using Spread.Entities.Main;

namespace Spread.Data.Management.Commands
{
    internal class DeleteLookUpCommand : IRequestHandler<DeleteLookUpByIdRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DeleteLookUpCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(DeleteLookUpByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<LookUp>();
            var entity = await repository.Get(x => !x.IsDeleted && x.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                return false;
            }
            repository.Delete(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}