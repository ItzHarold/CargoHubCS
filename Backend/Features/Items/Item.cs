using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Features.Items
{
    [Table("Items")]
    public class Item : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("uid")]
        public required string Uid { get; set; }

        [Required]
        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public required string Description { get; set; }

        [JsonPropertyName("short_description")]
        public string? ShortDescription { get; set; }

        [JsonPropertyName("upc_code")]
        public string? UpcCode { get; set; }

        [JsonPropertyName("model_number")]
        public string? ModelNumber { get; set; }

        [JsonPropertyName("commodity_code")]
        public string? CommodityCode { get; set; }

        [Required]
        [ForeignKey("ItemLine")]
        [JsonPropertyName("item_line")]
        public required int ItemLine { get; set; }

        [Required]
        [ForeignKey("ItemGroup")]
        [JsonPropertyName("item_group")]
        public required int ItemGroup { get; set; }

        [Required]
        [ForeignKey("ItemType")]
        [JsonPropertyName("item_type")]
        public required int ItemType { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        [JsonPropertyName("supplier_id")]
        public required int SupplierId { get; set; }
    }
}
