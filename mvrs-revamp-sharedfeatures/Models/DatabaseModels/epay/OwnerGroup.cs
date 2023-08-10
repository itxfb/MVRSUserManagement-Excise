using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatabaseModels.epay
{
    public class OwnerGroup : BaseModel
    {
        [Key]
        public long OwnerGroupId { get; set; }

        [ForeignKey("Owner")]
        public long OwnerId { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("Person")]
        public long? PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("Business")]
        public long? BusinessId { get; set; }
        public virtual Business Business { get; set; }

        public bool IsFirstGroupMember { get; set; }
    }
}
