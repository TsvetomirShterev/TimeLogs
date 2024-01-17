using AutoMapper;
using TimeLogs.DB.Commands.Users;
using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUserCommands userCommands;
    public UserService(IMapper mapper, IUserCommands userCommands)
    {
        this.mapper = mapper;
        this.userCommands = userCommands;
    }

    public User CreateUser(CreateUserModel createUserModel)
    {
        var user = mapper.Map<CreateUserModel, User>(createUserModel);

        return this.userCommands.CreateUser(user);
    }
}
