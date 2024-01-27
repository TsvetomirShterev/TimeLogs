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

    public IEnumerable<TimeLog> GetTimeLogs()
    {
        var timeLogs = this.dbContext.TimeLogs
            .Include(timeLog => timeLog.User)
            .Include(timeLog => timeLog.Project)
            .ToArray();

        return timeLogs;
    }

    public int GetTimeLogsCount()
    {
        var timeLogsCount = this.dbContext.TimeLogs
            .Count();

        return timeLogsCount;
    }

    private static IQueryable<TimeLog> AddDateIfHasValue(DateTime? fromDate, DateTime? toDate, IQueryable<TimeLog> query)
    {
        if (fromDate.HasValue && toDate.HasValue)
        {
            query = query.Where(timeLog => timeLog.LogDate >= fromDate.Value && timeLog.LogDate <= toDate.Value);
        }

        return query;
    }

}
