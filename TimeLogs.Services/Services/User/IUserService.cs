using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Services.User;

public interface IUserService
{
    CreateUserModel CreateUser(CreateUserModel createUserModel);
}
