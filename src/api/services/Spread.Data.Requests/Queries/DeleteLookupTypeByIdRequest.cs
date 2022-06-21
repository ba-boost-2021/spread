using MediatR;

namespace Spread.Data.Query.Requests;

public class DeleteLookupTypeByIdRequest:IRequest<bool>
{
    public DeleteLookupTypeByIdRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
