using Models.DatabaseModels.VehicleRegistration.Core;
using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class User : BaseModel
    {
        [Key]
        public long UserId { get; set; }

        //[NotMapped]
        //[ForeignKey("Person")]
        public long? PersonId { get; set; }
        //public virtual Person Person { get; set; }


        //[ForeignKey("Business")]
        public long? BusinessId { get; set; }
        //public virtual Business Business { get; set; }

        //[ForeignKey("District")]
        public long? UserDistrictId { get; set; }
        //public virtual District District { get; set; }

        //[ForeignKey("UserStatus")]
        public long UserStatusId { get; set; }
        //public virtual UserStatus UserStatus { get; set; }

        //[ForeignKey("UserType")]
        public long? UserTypeId { get; set; }
        //public virtual UserType UserType { get; set; }

        //[ForeignKey("SiteOffice")]
        public long? SiteOfficeId { get; set; }
        //public virtual SiteOffice SiteOffice { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public new long? CreatedBy { get; set; }
    }
}
