using AutoMapper;
using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Projects;

namespace TimeLogs.Services.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectModel, Project>();
    }
}
