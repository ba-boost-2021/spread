using AutoMapper;
using MediatR;
using Spread.Data.Abstractions;
using Spread.Data.Requests.Contracts;
using Spread.Data.Requests.Queries;
using Spread.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Management.Queries
{
    internal class GetLookupTypeByIdQuery: IRequestHandler<GetLookupTypeByIdRequest, LookupTypeDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetLookupTypeByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<LookupTypeDto> Handle(GetLookupTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<LookupType>();
            var entity = await repository.Get(f => !f.IsDeleted && f.Id == request.Id, cancellationToken);
            if (entity is null)
            {
                return null;
            }
            var result = mapper.Map<LookupTypeDto>(entity);
            return result;
        }
    }
}
