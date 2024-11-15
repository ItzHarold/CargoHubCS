using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Items
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Uid { get; set; }

        [Required]
        public required string Code { get; set; }

        [Required]
        public required string Description { get; set; }

        public string? ShortDescription { get; set; }

        public string? UpcCode { get; set; }

        public string? ModelNumber { get; set; }

        public string? CommodityCode { get; set; }

        [Required]
        [ForeignKey("ItemLine")]
        public required int ItemLine { get; set; }

        [Required]
        [ForeignKey("ItemGroup")]
        public required int ItemGroup { get; set; }

        [Required]
        [ForeignKey("ItemType")]
        public required int ItemType { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        public required int SupplierId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
