using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Inventories
{
    [Table("Inventories")]
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required] [ForeignKey("Items")] public required string ItemId { get; set; }

        [Required] public required int TotalOnHand { get; set; }

        [Required] public required int TotalExpected { get; set; }

        [Required] public required int TotalOrdered { get; set; }

        [Required] public required int TotalAllocated { get; set; }

        [Required] public required int TotalAvailable { get; set; }

        public string? Description { get; set; }

        [Required] public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
