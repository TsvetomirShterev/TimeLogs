using TimeLogs.DB.Commands.Projects;
using TimeLogs.DB.Commands.Users;
using TimeLogs.DB.Queries.TimeLogs;
using TimeLogs.DB.Queries.Users;
using TimeLogs.Services.Services.TimeLogs;

namespace TimeLogs.API.Infrastructure;

public static class ServiceSettings
{
    public static void BuildServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserCommands, UserCommands>();
        builder.Services.AddScoped<IUserQueries, UserQueries>();

        builder.Services.AddScoped<IProjectCommands, ProjectCommands>();

        builder.Services.AddScoped<ITimeLogService, TimeLogService>();
        builder.Services.AddScoped<ITimeLogQueries, TimeLogQueries>();
    }
}
