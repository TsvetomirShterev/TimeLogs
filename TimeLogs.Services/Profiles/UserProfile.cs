using AutoMapper;
using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Users;

namespace TimeLogs.Services.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, User>();

        CreateMap<User, ReadUserModel>();
    }
}
