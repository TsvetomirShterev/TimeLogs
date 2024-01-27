using TimeLogs.Services.Dto.TimeLogs;

namespace TimeLogs.Services.Services.TimeLogs;

public interface ITimeLogService
{
    IEnumerable<ReadTimeLogModel> GetTimeLogs(int page, int itemsPerPage, DateTime? fromDate = null, DateTime? toDate = null);

    int GetTimeLogsCount(DateTime? fromDate = null, DateTime? toDate = null);
}
