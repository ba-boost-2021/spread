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
    }
}
