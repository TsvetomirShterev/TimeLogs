using AutoMapper;
using TimeLogs.DB.Commands.Users;
using TimeLogs.DB.Entities;
using TimeLogs.DB.Queries.Users;
using TimeLogs.Services.Dto.Projects;
using TimeLogs.Services.Dto.TimeLogs;
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

    public IEnumerable<ReadUserModel> GetUsers(int page, int itemsPerPage)
    {
        var usersFromDB = this.usersQueries.GetUsers();

        var users = this.MapUsers(usersFromDB)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage);

        return users;
    }

    private IEnumerable<ReadUserModel> MapUsers(IEnumerable<User> users)
    {
        var mappedUsers = users.Select(user => new ReadUserModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            TimeLogs = user.TimeLogs.Select(timeLog => new ReadTimeLogModel
            {
                Id = timeLog.Id,
                LogDate = timeLog.LogDate,
                HoursWorked = timeLog.HoursWorked,
                Project = new ReadProjectModel
                {
                    Id = timeLog.Project.Id,
                    Name = timeLog.Project.Name
                }
            }).ToList()
        }).ToList();

        return mappedUsers;
    }
}
