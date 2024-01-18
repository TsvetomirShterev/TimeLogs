using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Services.Users;

public interface IUserService
{
    User CreateUser(CreateUserModel createUserModel);

    IEnumerable<ReadUserModel> GetUsers();
}
