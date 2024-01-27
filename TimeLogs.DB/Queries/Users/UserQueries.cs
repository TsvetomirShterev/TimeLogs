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

    public int GetUsersCount(DateTime? fromDate = null, DateTime? toDate = null)
    {
        var query = this.dbContext.Users
            .Include(user => user.TimeLogs)
            .AsQueryable();

        query = AddDateIfValuePresent(fromDate, toDate, query);

        var userCount = query.Count();

        return userCount;
    }

    public IEnumerable<User> GetUsers(int page = 1, int itemsPerPage = 10, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var query = this.dbContext.Users
            .Include(user => user.TimeLogs)
                .ThenInclude(timeLog => timeLog.Project)
            .OrderBy(user => user.TimeLogs.Min(timeLog => timeLog.LogDate))
            .AsQueryable();

        query = AddDateIfValuePresent(fromDate, toDate, query);

        var users = query
            .Select(user => new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                TimeLogs = user.TimeLogs.Where(timeLog =>
                    (!fromDate.HasValue || timeLog.LogDate >= fromDate.Value) &&
                    (!toDate.HasValue || timeLog.LogDate <= toDate.Value)
                )
                .ToArray()
            })
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToArray();

        return users;
    }

    private static IQueryable<User> AddDateIfValuePresent(DateTime? fromDate, DateTime? toDate, IQueryable<User> query)
    {
        if (fromDate.HasValue || toDate.HasValue)
        {
            query = query.Where(user =>
                user.TimeLogs.Any(timeLog =>
                    (!fromDate.HasValue || timeLog.LogDate >= fromDate.Value) &&
                    (!toDate.HasValue || timeLog.LogDate <= toDate.Value)
                )
            );
        }

        return query;
    }
}
