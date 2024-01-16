namespace TimeLogs.DB.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TimeLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime LogDate { get; set; }

    [Required]
    public float HoursWorked { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}

