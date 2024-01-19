using System.ComponentModel.DataAnnotations;
using TimeLogs.DB.Entities;
using TimeLogs.Services.Dto.Projects;

namespace TimeLogs.Services.Dto.TimeLogs;

public class ReadTimeLogModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime LogDate { get; set; }

    [Required]
    public float HoursWorked { get; set; }

    public ReadProjectModel Project { get; set; }
}
