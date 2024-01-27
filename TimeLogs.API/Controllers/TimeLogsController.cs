using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TimeLogs.Services.Dto.TimeLogs;
using TimeLogs.Services.Services.TimeLogs;

namespace TimeLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogsController : ControllerBase
    {
        private readonly ITimeLogService timeLogsService;
        public TimeLogsController(ITimeLogService timeLogsService)
        {
            this.timeLogsService = timeLogsService;
        }

        [HttpGet]
        public ActionResult<ReadTimeLogModel> GetTimeLogs()
        {
            var timeLogs = this.timeLogsService.GetTimeLogs();

            return Ok(timeLogs);
        }

        [HttpGet("Count")]
        public ActionResult<int> GetTimeLogsCount()
        {
            var timeLogsCount = this.timeLogsService.GetTimeLogsCount();

            return Ok(timeLogsCount);
        }
    }
}
