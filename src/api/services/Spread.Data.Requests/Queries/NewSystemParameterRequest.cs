using MediatR;
using Spread.Data.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Requests.Queries
{
    public class NewSystemParameterRequest : IRequest<bool>
    {
        public NewSystemParameterRequest(NewSystemParameterRequestDto data)
        {
            Data = data;
        }

        public NewSystemParameterRequestDto Data { get; }
    }
}
