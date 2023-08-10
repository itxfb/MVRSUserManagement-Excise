using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.epay
{
    public class Person : BaseModel
    {
        [Key]
        public long PersonId { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

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
