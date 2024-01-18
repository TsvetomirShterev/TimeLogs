using AutoMapper;
using TimeLogs.DB.Commands.Projects;
using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Projects;

namespace TimeLogs.Services.Services.Projects;

public class ProjectService : IProjectService
{
    private readonly IMapper mapper;
    private readonly IProjectCommands projectCommands;
    public ProjectService(IMapper mapper, IProjectCommands projectCommands)
    {
        this.mapper = mapper;
        this.projectCommands = projectCommands;
    }

    public Project CreateProject(CreateProjectModel createProjectModel)
    {
        var project = this.mapper.Map<CreateProjectModel, Project>(createProjectModel);

        return this.projectCommands.CreateProject(project);
    }
}
