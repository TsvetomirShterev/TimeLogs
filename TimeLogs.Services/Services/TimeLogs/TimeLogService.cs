﻿using TimeLogs.DB.Entities;
using TimeLogs.DB.Queries.TimeLogs;
using TimeLogs.Services.Dto.TimeLogs;

using TimeLogs.Services.Dto.Projects;
using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Services.TimeLogs;

public class TimeLogService : ITimeLogService
{
    private readonly ITimeLogQueries timeLogQueries;

    public TimeLogService(ITimeLogQueries timeLogQueries)
    {
        this.timeLogQueries = timeLogQueries;
    }

    public IEnumerable<ReadTimeLogModel> GetTimeLogs(int page, int itemsPerPage, DateTime? fromDate = null, DateTime? toDate = null)
    {
        var timeLogsFromDb = this.timeLogQueries
            .GetTimeLogs(page, itemsPerPage, fromDate, toDate);

        var timeLogs = MapTimeLogs(timeLogsFromDb);

        return timeLogs;
    }

    public int GetTimeLogsCount(DateTime? fromDate = null, DateTime? toDate = null)
    {
        var timeLogsCount = this.timeLogQueries.GetTimeLogsCount(fromDate, toDate);

        return timeLogsCount;
    }

    private IEnumerable<ReadTimeLogModel> MapTimeLogs(IEnumerable<TimeLog> timeLogsFromDb)
    {
        var mappedTimeLogs = timeLogsFromDb
            .Select(timeLog => new ReadTimeLogModel()
            {
                Id = timeLog.Id,
                LogDate = timeLog.LogDate,
                HoursWorked = timeLog.HoursWorked,
                Project = new ReadProjectModel
                {
                    Id = timeLog.ProjectId,
                    Name = timeLog.Project.Name,
                },
                User = new ReadUserModel
                {
                    Id = timeLog.UserId,
                    FirstName = timeLog.User.FirstName,
                    LastName = timeLog.User.LastName,
                    Email = timeLog.User.Email,
                }
            })
            .ToArray();

        return mappedTimeLogs;
    }
}
