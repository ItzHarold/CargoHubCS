using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Features.Items;

namespace Backend.Features.Shipments
{
    [Table("Shipments")]
    public class Shipment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        [ForeignKey("Order")]
        public required int OrderId { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        public required int SourceId { get; set; }

        [Required]
        public required DateTime OrderDate { get; set; }

        [Required]
        public required DateTime RequestDate { get; set; }

        [Required]
        public required DateTime ShipmentDate { get; set; }

        [Required]
        public required string ShipmentType { get; set; }

        [Required]
        public required string ShipmentStatus { get; set; }

        public string? Notes { get; set; }

        [Required]
        public required string CarrierCode { get; set; }

        public string? CarrierDescription { get; set; }

        [Required]
        public required string ServiceCode { get; set; }

        [Required]
        public required string PaymentType { get; set; }

        [Required]
        public required string TransferMode { get; set; }

        [Required]
        public required int TotalPackageCount { get; set; }

        [Required]
        public required decimal TotalPackageWeight { get; set; }

        [Required]
        public required List<Item> Items { get; set; }

    }
}
