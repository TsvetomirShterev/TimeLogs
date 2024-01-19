using System.ComponentModel.DataAnnotations;

namespace TimeLogs.Services.Dto.Projects;

public class ReadProjectModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}
