using System.ComponentModel.DataAnnotations;
using TimeLogs.DB.Entities;

namespace TimeLogs.Services.Dto.Projects;

public class CreateProjectModel
{
    [Required]
    public string Name { get; set; }

    public ICollection<TimeLog> TimeLogs { get; set; } = new HashSet<TimeLog>();
}
