using TimeLogs.Services.Services.User;

namespace TimeLogs.API.Infrastructure;

public class ServiceSettings
{
    public static void BuildServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
    }
}
