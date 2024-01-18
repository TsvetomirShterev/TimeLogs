using System.ComponentModel.DataAnnotations;
using TimeLogs.DB.Entities;

namespace TimeLogs.Services.Dto.Users;

public class ReadUserModel
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    public ICollection<TimeLog> TimeLogs { get; set; } = new HashSet<TimeLog>();
}
