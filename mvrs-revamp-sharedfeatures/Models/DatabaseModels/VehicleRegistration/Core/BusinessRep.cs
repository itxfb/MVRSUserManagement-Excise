using Models.DatabaseModels.VehicleRegistration.Setup;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class BusinessRep : BaseModel
    {
        [Key]
        public long BusinessRepId { get; set; }

        [ForeignKey("Business")]
        public long BusinessId { get; set; }
        public virtual Business Business { get; set; }

        [ForeignKey("BusinessRepStatus")]
        public long BusinessRepStatusId { get; set; }
        public virtual BusinessRepStatus BusinessRepStatus { get; set; }

        [ForeignKey("Person")]
        public long PersonId { get; set; }
        public virtual Person Person { get; set; }

        public bool? IsOwner { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Designation { get; set; }
    }

}
