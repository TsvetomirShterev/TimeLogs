using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Queries.TimeLogs;

public interface ITimeLogQueries
{
    IEnumerable<TimeLog> GetTimeLogs();

    int GetTimeLogsCount();
}
