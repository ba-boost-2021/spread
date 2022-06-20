using Spread.Data.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Services.Concretes
{
    internal class LookupTypeService : ILookupTypeService
    {
        private readonly IMediator mediator;

        public LookupTypeService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public Task<bool> CreateLookupType(NewLookupTypeRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewLookupTypeRequest(data), cancellationToken);
        }

        public Task<List<LookupTypeDto>> GetAll(CancellationToken cancellationToken)
        {
            return mediator.Send(new LookupTypeListRequest(), cancellationToken);
        }

        public Task<bool> LookupTypeDeleteById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteLookupTypeByIdRequest(id), cancellationToken);
        }

        public Task<LookupTypeDto> LookupTypeGetById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new GetLookupTypeByIdRequest(id), cancellationToken);
        }
    }
}
