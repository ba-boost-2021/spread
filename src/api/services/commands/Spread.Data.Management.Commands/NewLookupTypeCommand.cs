using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Queries;
using Spread.Entities.Main;

namespace Spread.Data.Management.Commands
{
    internal class NewLookupTypeCommand : IRequestHandler<NewLookupTypeRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewLookupTypeCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewLookupTypeRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Data.Name))
            {
                return false;
            }
            var repository = unitOfWork.GetRepository<LookupType>();
            var conflict = await repository.Get(f => f.IsActive && !f.IsDeleted && f.Name == request.Data.Name, cancellationToken);
            if (conflict is not null)
            {
                return false;
            }
            var entity = mapper.Map<LookupType>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}