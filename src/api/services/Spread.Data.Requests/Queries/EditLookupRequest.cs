using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class EditLookupRequest : IRequest<bool>
{
   
    public EditLookupRequest(EditLookupRequestDto data)
    {
        Data = data;
    }

    public EditLookupRequestDto Data { get; }
}
