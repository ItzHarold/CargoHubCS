using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Suppliers
{
    [Table("Suppliers")]
    public class Supplier : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        public required string Code { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Address { get; set; }

        public string? AddressExtra { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string ZipCode { get; set; }

        [Required]
        public required string Province { get; set; }

        [Required]
        public required string Country { get; set; }

        [Required]
        public required string ContactName { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        [Required]
        public required string Reference { get; set; }
    }
}
