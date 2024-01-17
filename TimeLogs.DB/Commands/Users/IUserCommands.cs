using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Commands.Users;

public interface IUserCommands
{
    User CreateUser(User user);
}
