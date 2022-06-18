using MediatR;
using Spread.Data.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spread.Data.Requests.Queries
{
    public class NewLookupTypeRequest: IRequest<bool>
    {
        public NewLookupTypeRequest(NewLookupTypeRequestDto data)
        {
            Data = data;
        }
        public NewLookupTypeRequestDto Data { get; set; }
    }
}
