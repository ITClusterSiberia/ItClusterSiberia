using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(150)]
        [Column(TypeName = "varchar(150)")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(350)]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; } // В реальном проекте хэшируйте пароли!

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}