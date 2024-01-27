using TimeLogs.Services.Dto.TimeLogs;

namespace TimeLogs.Services.Services.TimeLogs;

public interface ITimeLogService
{
    IEnumerable<ReadTimeLogModel> GetTimeLogs();

    int GetTimeLogsCount();
}
