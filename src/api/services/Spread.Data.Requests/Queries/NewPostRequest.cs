using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class NewPostRequest : IRequest<bool>
{
    public NewPostRequest(PostDto data)
    {
        Data = data;
    }

    public PostDto Data { get; }
}
