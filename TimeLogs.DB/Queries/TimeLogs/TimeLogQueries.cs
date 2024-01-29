using Azure;
using Microsoft.EntityFrameworkCore;
using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Queries.TimeLogs;

public class TimeLogQueries : ITimeLogQueries
{
    private readonly TimeLogsDbContext dbContext;

    public TimeLogQueries(TimeLogsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<TimeLog> GetTimeLogs(int page = 1, int itemsPerPage = 10, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var query = this.dbContext.TimeLogs
            .Include(timeLog => timeLog.User)
            .Include(timeLog => timeLog.Project)
            .OrderByDescending(timeLog => timeLog.LogDate)
            .AsQueryable();

        query = AddDateIfHasValue(fromDate, toDate, query);

        var timeLogs = query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToArray();

        return timeLogs;
    }

    public int GetTimeLogsCount(DateTime? fromDate = null, DateTime? toDate = null)
    {
        var query = this.dbContext.TimeLogs
            .AsQueryable();

        query = AddDateIfHasValue(fromDate, toDate, query);

        var timeLogsCount = query.Count();

        return timeLogsCount;
    }

    private IQueryable<TimeLog> AddDateIfHasValue(DateTime? fromDate, DateTime? toDate, IQueryable<TimeLog> query)
    {
        if (fromDate.HasValue && toDate.HasValue)
        {
            query = query.Where(timeLog => timeLog.LogDate >= fromDate.Value && timeLog.LogDate <= toDate.Value);
        }

        return query;
    }

}
