using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Backend.Features.Locations;

namespace Backend.Features.Inventories
{
    [Table("Inventories")]
    public class Inventory : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [Required]
        [JsonPropertyName("item_code")]
        [ForeignKey("Items")] public required string ItemCode { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("item_reference")]
        public string? ItemReference { get; set; }

        [Required]
        [JsonPropertyName("location_id")]
        public required int[] LocationId { get; set; }

        [Required]
        [JsonPropertyName("total_on_hand")]
        public required int TotalOnHand { get; set; }

        [Required]
        [JsonPropertyName("total_expected")]
        public required int TotalExpected { get; set; }

        [Required]
        [JsonPropertyName("total_ordered")]
        public required int TotalOrdered { get; set; }

        [Required]
        [JsonPropertyName("total_allocated")]
        public required int TotalAllocated { get; set; }

        [Required]
        [JsonPropertyName("total_available")]
        public required int TotalAvailable { get; set; }

    }
}
