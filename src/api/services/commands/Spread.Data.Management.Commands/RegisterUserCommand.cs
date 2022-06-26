using AutoMapper;
using MediatR;
using Spread.Common.Extensions;
using Spread.Data.Abstractions;
using Spread.Data.Query.Requests;
using Spread.Entities.Profile;

namespace Spread.Data.Management.Commands;
internal class RegisterUserCommand : IRequestHandler<RegisterUserRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public RegisterUserCommand(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<bool> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.GetRepository<User>();
        var existingUser = await repository.Get(f => f.EMail == request.Data.EMail || f.UserName == request.Data.UserName, 
                                                cancellationToken);
        if (existingUser != null)
        {
            return false;
        }
        var entity = mapper.Map<User>(request.Data);
        entity.PasswordHash = Guid.NewGuid().ToString();
        entity.Password = (request.Data.Password + entity.PasswordHash).CreateHash();
        entity.VerificationId = Guid.NewGuid().ToString();
        repository.Insert(entity);
        var result = await unitOfWork.SaveChanges(cancellationToken);
        return result > 0;
    }
}