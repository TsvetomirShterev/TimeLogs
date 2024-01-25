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

    public IEnumerable<User> GetSortedUsers(int page = 1, int itemsPerPage = 10, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var query = this.dbContext.Users
            .Include(user => user.TimeLogs)
                .ThenInclude(timeLog => timeLog.Project)
            .OrderBy(user => user.FirstName)
            .ThenBy(user => user.LastName)
            .AsQueryable();

        if (fromDate.HasValue)
        {
            query = query.Where(user => user.TimeLogs.Any(timeLog => timeLog.LogDate >= fromDate.Value));
        }

        if (toDate.HasValue)
        {
            query = query.Where(user => user.TimeLogs.Any(timeLog => timeLog.LogDate <= toDate.Value));
        }

        var sortedUsers = query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToArray();

        return sortedUsers;
    }


    public IEnumerable<User> GetUsers()
    {
        var users = this.dbContext.Users
            .Include(user => user.TimeLogs)
                .ThenInclude(timeLog => timeLog.Project)
            .OrderBy(user => user.FirstName)
            .ThenBy(user => user.LastName)
            .ToArray();

        return users;
    }
}
