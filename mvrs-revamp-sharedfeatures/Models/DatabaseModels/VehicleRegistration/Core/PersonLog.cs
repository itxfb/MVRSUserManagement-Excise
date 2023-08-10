using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class PersonLog : BaseModel
    {
        [Key]
        public long PersonLogId { get; set; }

        [ForeignKey("Person")]
        public long PersonId { get; set; }
        public virtual Person Person { get; set; }
        
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
