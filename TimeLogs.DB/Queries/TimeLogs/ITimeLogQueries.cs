using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Queries.TimeLogs;

public interface ITimeLogQueries
{
    IEnumerable<TimeLog> GetTimeLogs(int page, int itemsPerPage, DateTime? fromDate = null, DateTime? toDate = null);

    int GetTimeLogsCount(DateTime? fromDate = null, DateTime? toDate = null);

    IEnumerable<TimeLog> GetTopTimeLogs(int topItems = 10, DateTime? fromDate = null, DateTime? toDate = null);
}
