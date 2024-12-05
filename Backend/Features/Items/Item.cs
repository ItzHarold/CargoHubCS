using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Items
{
    [Table("Items")]
    public class Item : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Uid { get; set; }

        [Required]
        public required string Code { get; set; }

        [Required]
        public required string Description { get; set; }

        public string? Short_Description { get; set; }

        public string? Upc_Code { get; set; }

        public string? Model_Number { get; set; }

        public string? Commodity_Code { get; set; }

        [Required]
        [ForeignKey("ItemLine")]
        public required int Item_Line { get; set; }

        [Required]
        [ForeignKey("ItemGroup")]
        public required int Item_Group { get; set; }

        [Required]
        [ForeignKey("ItemType")]
        public required int Item_Type { get; set; }

        [Required]
        [ForeignKey("Supplier")]
        public required int Supplier_Id { get; set; }
    }
}
