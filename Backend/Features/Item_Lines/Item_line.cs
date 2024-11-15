using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.ItemLines
{
    [Table("Item_Lines")]
    public class ItemLine : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
