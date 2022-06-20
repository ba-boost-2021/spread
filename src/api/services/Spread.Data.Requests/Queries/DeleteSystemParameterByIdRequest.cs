using MediatR;

namespace Spread.Data.Query.Requests;

public class DeleteSystemParameterByIdRequest:IRequest<bool>
{
    public DeleteSystemParameterByIdRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}