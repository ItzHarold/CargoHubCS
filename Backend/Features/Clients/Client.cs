using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Clients
{
    [Table("Clients")]
    public class Client
    {
        [Key]
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
        public required string Country { get; set; }

        [Required]
        public required Contact Contact { get; set; }
    }
}
