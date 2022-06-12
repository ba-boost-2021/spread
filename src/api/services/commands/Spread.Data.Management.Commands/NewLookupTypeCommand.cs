using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Queries;
using Spread.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var entity = mapper.Map<LookupType>(request.Data);
            var repository = unitOfWork.GetRepository<LookupType>();
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
