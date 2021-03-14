using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvolentHealth.Directory.Contact.Repository.Models
{
    [Table("ContactInfo")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("FirstName",TypeName = "varchar(30)")]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Column("LastName", TypeName = "varchar(30)")]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Column("Email",TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column("PhoneNumber",TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [Column("Status", TypeName = "varchar(10)")]
        public string Status { get; set; }
    }
}
