using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Backend.Features.Items;

namespace Backend.Features.Shipments
{
    [Table("Shipments")]
    public class Shipment : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [Required]
        [ForeignKey("Order")]
        [JsonPropertyName("order_id")]
        public required int OrderId { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        [JsonPropertyName("source_id")]
        public required int SourceId { get; set; }

        [JsonPropertyName("order_date")]
        public DateTime? OrderDate { get; set; }

        [JsonPropertyName("request_date")]
        public DateTime? RequestDate { get; set; }

        [JsonPropertyName("shipment_date")]
        public DateTime? ShipmentDate { get; set; }

        [Required]
        [JsonPropertyName("shipment_type")]
        public required string ShipmentType { get; set; }

        [JsonPropertyName("shipment_status")]
        public string? ShipmentStatus { get; set; }

        [JsonPropertyName("notes")]
        public string? Notes { get; set; }

        [Required]
        [JsonPropertyName("carrier_code")]
        public required string CarrierCode { get; set; }

        [JsonPropertyName("carrier_description")]
        public string? CarrierDescription { get; set; }

        [Required]
        [JsonPropertyName("service_code")]
        public required string ServiceCode { get; set; }

        [Required]
        [JsonPropertyName("payment_type")]
        public required string PaymentType { get; set; }

        [Required]
        [JsonPropertyName("transfer_mode")]
        public required string TransferMode { get; set; }

        [JsonPropertyName("total_package_count")]
        public int? TotalPackageCount { get; set; }

        [JsonPropertyName("total_package_weight")]
        public float? TotalPackageWeight { get; set; }

        [Required]
        [JsonPropertyName("items")]
        public required List<Item> Items { get; set; }
    }
}
