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
    public class GetSystemParameterByIdQuery : IRequestHandler<GetSystemParameterByIdRequest, SystemParameterDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetSystemParameterByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<SystemParameterDto> Handle(GetSystemParameterByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<SystemParameter>();
            var entity = await repository.Get(s => s.IsActive && s.Id == request.Id, cancellationToken);
            if (entity is null)
            {
                return null;
            }
            var result = mapper.Map<SystemParameterDto>(entity);
            return result;
        }
    }
}
