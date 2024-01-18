using AutoMapper;
using TimeLogs.DB.Commands.Projects;
using TimeLogs.DB.Commands.Users;
using TimeLogs.DB.Queries.Users;
using TimeLogs.Services.Profiles;
using TimeLogs.Services.Services.Projects;
using TimeLogs.Services.Services.Users;

namespace TimeLogs.API.Infrastructure;

public class ServiceSettings
{
    public static void BuildServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserCommands, UserCommands>();
        builder.Services.AddScoped<IUserQueries, UserQueries>();

        builder.Services.AddScoped<IProjectService, ProjectService>();
        builder.Services.AddScoped<IProjectCommands, ProjectCommands>();

        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new ProjectProfile());
            config.AddProfile(new UserProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
    }
}
