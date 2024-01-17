using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Commands.Users;

public class UserCommands : IUserCommands
{
    private readonly TimeLogsDbContext timeLogsDbContext;
    public UserCommands(TimeLogsDbContext timeLogsDbContext)
    {
        this.timeLogsDbContext = timeLogsDbContext;
    }

    public User CreateUser(User user)
    {
        this.timeLogsDbContext.Users.Add(user);
        this.timeLogsDbContext.SaveChanges();
        return user;
    }
}
