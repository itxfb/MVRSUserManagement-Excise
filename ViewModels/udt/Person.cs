using System.ComponentModel.DataAnnotations;

namespace UserManagement.ViewModels.udt
{
    public class Person : BaseModel
    {
        [Key]
        public long PersonId { get; set; }
        public long CountryId { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonName { get; set; }

        [StringLength(50)]
        public string FatherHusbandName { get; set; }

        [Required]
        [StringLength(13)]
        public string CNIC { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(15)]
        public string OldCNIC { get; set; }

        [StringLength(20)]
        public string NTN { get; set; }

        [StringLength(20)]
        public string FTN { get; set; }



    }
}
