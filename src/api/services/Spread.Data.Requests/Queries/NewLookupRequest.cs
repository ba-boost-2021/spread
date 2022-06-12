using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class NewLookupRequest : IRequest<bool>
{
    public NewLookupRequest(NewLookupRequestDto data)
    {
        Data = data;
    }

    public NewLookupRequestDto Data { get; }
}
