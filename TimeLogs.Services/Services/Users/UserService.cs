using AutoMapper;
using TimeLogs.DB.Commands.Users;
using TimeLogs.DB.Entities;
using TimeLogs.DB.Queries.Users;
using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUserCommands userCommands;
    private readonly IUserQueries usersQueries;
    public UserService(IMapper mapper, IUserCommands userCommands, IUserQueries usersQueries)
    {
        this.mapper = mapper;
        this.userCommands = userCommands;
        this.usersQueries = usersQueries;
    }

    public User CreateUser(CreateUserModel createUserModel)
    {
        var user = mapper.Map<CreateUserModel, User>(createUserModel);

        return this.userCommands.CreateUser(user);
    }

    public IEnumerable<ReadUserModel> GetUsers()
    {
        var users = this.usersQueries.GetUsers();

        return mapper.Map<IEnumerable<User>, List<ReadUserModel>>(users);
    }
}
