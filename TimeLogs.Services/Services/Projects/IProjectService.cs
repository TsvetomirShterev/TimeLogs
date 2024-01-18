using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Projects;

namespace TimeLogs.Services.Services.Projects;

public interface IProjectService
{
    Project CreateProject (CreateProjectModel createProjectModel);    
}
