using Microsoft.AspNetCore.Mvc;
using TimeLogs.Services.Dto.Projects;
using TimeLogs.Services.Services.Projects;

namespace TimeLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpPost]
        public ActionResult<CreateProjectModel> CreateProject([FromForm] CreateProjectModel createProjectModel)
        {
            var createdProject = projectService.CreateProject(createProjectModel);

            if (createdProject == null)
            {
                return BadRequest();
            }

            return Created("api/[controller]", createdProject);
        }
    }
}
