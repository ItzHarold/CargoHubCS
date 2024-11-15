using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.ItemGroups;

[Table("Item_Groups")]
public class ItemGroup : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }
}
