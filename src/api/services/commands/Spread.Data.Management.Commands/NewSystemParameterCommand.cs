using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Queries;
using Spread.Entities.Main;

namespace Spread.Data.Management.Commands
{
    internal class NewSystemParameterCommand : IRequestHandler<NewSystemParameterRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewSystemParameterCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewSystemParameterRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Data.Value) || string.IsNullOrEmpty(request.Data.Key))
            {
                return false;
            }
            var repository = unitOfWork.GetRepository<SystemParameter>();
            var conflict = await repository.Get(f => f.IsActive
                                                    && !f.IsDeleted
                                                    && f.Key == request.Data.Key, cancellationToken);
            if (conflict is not null)
            {
                return false;
            }
            var entity = mapper.Map<SystemParameter>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }

        
    }
}