using System.ComponentModel.DataAnnotations;
using TimeLogs.Services.Dto.TimeLogs;

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

    public ICollection<ReadTimeLogModel> TimeLogs { get; set; } = new HashSet<ReadTimeLogModel>();
}
