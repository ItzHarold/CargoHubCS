using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Locations
{
    [Table("Locations")]
    public class Location : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        [ForeignKey("Warehouse")]
        public required int WarehouseId { get; set; }

        [Required]
        public required string Code { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
