using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Features.Items;

namespace Backend.Features.Orders
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        public required int SourceId { get; set; }

        [Required]
        public required DateTime OrderDate { get; set; }

        [Required]
        public required DateTime RequestDate { get; set; }

        [Required]
        public required string Reference { get; set; }

        public string? ReferenceExtra { get; set; }

        [Required]
        public required string OrderStatus { get; set; }

        public string? Notes { get; set; }

        public string? ShippingNotes { get; set; }

        public string? PickingNotes { get; set; }

        [Required]
        [ForeignKey("Warehouse")]
        public required int WarehouseId { get; set; }

        [Required]
        [ForeignKey("Client")]
        public required string ShipTo { get; set; }

        [Required]
        [ForeignKey("Client")]
        public required string BillTo { get; set; }

        [ForeignKey("Shipment")]
        public int? ShipmentId { get; set; }

        [Required]
        public required decimal TotalAmount { get; set; }

        public decimal? TotalDiscount { get; set; }

        public decimal? TotalTax { get; set; }

        public decimal? TotalSurcharge { get; set; }

        public required List<Item> Items { get; set; }
    }
}
