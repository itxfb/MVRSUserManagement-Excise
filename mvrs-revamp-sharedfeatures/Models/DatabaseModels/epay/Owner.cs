using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.epay
{
    public class Owner : BaseModel
    {
        [Key]
        public long OwnerId { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        [ForeignKey("OwnerType")]
        public long OwnerTypeId { get; set; }
        public virtual OwnerType OwnerType { get; set; }

        [ForeignKey("OwnerTaxGroup")]
        public long? OwnerTaxGroupId { get; set; }
        public virtual OwnerTaxGroup OwnerTaxGroup { get; set; }

        [ForeignKey("Person")]
        public long? PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Business")]
        public long? BusinessId { get; set; }
        public virtual Business Business { get; set; }

        public bool IsFirstGroupMember { get; set; }
    }
}
