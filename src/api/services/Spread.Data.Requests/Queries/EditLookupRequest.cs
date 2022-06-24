using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class EditLookupRequest : IRequest<bool>
{
   
    public EditLookupRequest(Guid id,EditLookupRequestDto data)
    {
        Id = id;
        Data = data;
    }

    public Guid Id { get; }
    public EditLookupRequestDto Data { get; }
}
