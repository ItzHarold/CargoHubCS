using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Transfers
{
    [Table("Transfers")]
    public class Transfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        public required string Reference { get; set; }

        [ForeignKey("WarehouseFrom")]
        public int? TransferFrom { get; set; }

        [Required]
        [ForeignKey("WarehouseTo")]
        public required int TransferTo { get; set; }

        [Required]
        public required string TransferStatus { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
