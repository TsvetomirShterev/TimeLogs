namespace TimeLogs.DB.Entities;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    public ICollection<TimeLog> TimeLogs { get; set; } = new HashSet<TimeLog>();
}
