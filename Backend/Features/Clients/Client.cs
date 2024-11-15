using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Clients
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Address { get; set; }

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
        public required string ContactPhone { get; set; }

        [Required]
        [EmailAddress]
        public required string ContactEmail { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
