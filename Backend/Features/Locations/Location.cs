using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Features.Locations
{
    [Table("Locations")]
    public class Location : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [Required]
        [ForeignKey("Warehouse")]
        [JsonPropertyName("warehouse_id")]
        public required int WarehouseId { get; set; }

        [Required]
        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [Required]
        [JsonPropertyName("row")]
        public required string Row { get; set; }

        [Required]
        [JsonPropertyName("rack")]
        public required string Rack { get; set; }

        [Required]
        [JsonPropertyName("shelf")]
        public required string Shelf { get; set; }
    }
}
