using MediatR;
using Spread.Data.Requests.Contracts;

namespace Spread.Data.Query.Requests;

public class SystemParameterListRequest : IRequest<List<SystemParameterDto>>
{

}