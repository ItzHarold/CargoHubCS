using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Features.Contacts
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Required]
        public required string ContactName { get; set; }

        [Required]
        public required string ContactPhone { get; set; }

        [Required]
        [EmailAddress]
        public required string ContactEmail { get; set; }
    }
}
