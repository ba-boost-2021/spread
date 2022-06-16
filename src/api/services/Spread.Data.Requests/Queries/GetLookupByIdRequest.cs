using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class GetLookupByIdRequest : IRequest<LookUpDto>
{
    public GetLookupByIdRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
