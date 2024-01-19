using Microsoft.EntityFrameworkCore;
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
        var users = dbContext.Users
            .Include(user => user.TimeLogs)
                .ThenInclude(timeLog => timeLog.Project)
            .ToList();

        return users;
    }
}
