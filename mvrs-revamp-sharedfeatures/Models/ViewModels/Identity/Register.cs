using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Identity
{
    public class Register
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(13)]
        public string CNIC { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
