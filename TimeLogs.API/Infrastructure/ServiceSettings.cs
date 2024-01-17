﻿using AutoMapper;
using TimeLogs.DB.Commands.Users;
using TimeLogs.Services.Profiles;
using TimeLogs.Services.Services.Users;

namespace TimeLogs.API.Infrastructure;

public class ServiceSettings
{
    public static void BuildServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserCommands, UserCommands>();

        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new UserProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
    }
}
