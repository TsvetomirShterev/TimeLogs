using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Queries.Users;

public class UserQueries : IUserQueries
{
    private readonly TimeLogsDbContext dbContext;
    public UserQueries(TimeLogsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<User> GetUsers()
    {
        return dbContext.Users.ToList();
    }
}
