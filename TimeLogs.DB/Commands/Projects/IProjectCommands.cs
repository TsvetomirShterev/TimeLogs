using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Commands.Projects;

public interface IProjectCommands
{
    Project CreateProject(Project project);
}
