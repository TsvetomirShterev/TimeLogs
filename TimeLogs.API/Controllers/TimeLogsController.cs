using Microsoft.AspNetCore.Mvc;
using TimeLogs.Services.Dto.TimeLogs;
using TimeLogs.Services.Services.TimeLogs;

namespace TimeLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogsController(ITimeLogService timeLogsService) : ControllerBase
    {
        private readonly ITimeLogService timeLogsService = timeLogsService;

        [HttpGet]
        public ActionResult<ReadTimeLogModel> GetTimeLogs([FromQuery] int page = 1, [FromQuery] int itemsPerPage = 10, [FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
        {
            var timeLogs = this.timeLogsService.GetTimeLogs(page, itemsPerPage, fromDate, toDate);

            return Ok(timeLogs);
        }

        [HttpGet("Count")]
        public ActionResult<int> GetTimeLogsCount([FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
        {
            var timeLogsCount = this.timeLogsService.GetTimeLogsCount(fromDate, toDate);

            return Ok(timeLogsCount);
        }

        [HttpGet("Top")]
        public ActionResult<ReadTimeLogModel> GetTopTimeLogs([FromQuery] int topItems = 10, [FromQuery] DateTime? fromDate = null, [FromQuery] DateTime? toDate = null)
        {
            var topTimeLogs = this.timeLogsService.GetTopTimeLogs(topItems, fromDate, toDate);

            return Ok(topTimeLogs);
        }
    }
}
