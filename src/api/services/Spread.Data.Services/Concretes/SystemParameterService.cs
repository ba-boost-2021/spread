using Spread.Data.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Services.Concretes
{
    internal class SystemParameterService:ISystemParameterService
    {
        private readonly IMediator mediator;

        public SystemParameterService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public Task<bool> CreateSystemParameter(NewSystemParameterRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewSystemParameterRequest(data), cancellationToken);
        }

        public Task<bool> DeleteSystemParameterById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteSystemParameterByIdRequest(id), cancellationToken);
        }

        public Task<List<SystemParameterDto>> GetAll(CancellationToken cancellationToken)
        {
            return mediator.Send(new SystemParameterListRequest(), cancellationToken);
        }

        public Task<SystemParameterDto> GetSystemParameterById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new GetSystemParameterByIdRequest(id), cancellationToken);
        }
    }
}
