using TimeLogs.DB.Entities;

namespace TimeLogs.DB.Commands.Projects;

public class ProjectCommands : IProjectCommands
{
    private readonly TimeLogsDbContext timeLogsDbContext;

    public ProjectCommands(TimeLogsDbContext timeLogsDbContext)
    {
        this.timeLogsDbContext = timeLogsDbContext;
    }

    public Project CreateProject(Project project)
    {
        this.timeLogsDbContext.Add(project);
        this.timeLogsDbContext.SaveChanges();
        return project;
    }
}
