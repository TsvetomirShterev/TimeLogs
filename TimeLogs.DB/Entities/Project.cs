namespace TimeLogs.DB.Entities;

using System.ComponentModel.DataAnnotations;

public class Project
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<TimeLog> TimeLogs { get; set; } = new HashSet<TimeLog>();
}
