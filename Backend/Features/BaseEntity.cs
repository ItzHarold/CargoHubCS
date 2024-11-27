using System.ComponentModel.DataAnnotations;

namespace Backend.Features;

public abstract class BaseEntity
{
    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
