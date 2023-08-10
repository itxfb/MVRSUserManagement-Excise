using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class WhitelistedClient : BaseModel
    {
        [Key]
        public long WhitelistedClientId { get; set; }

        [ForeignKey("AssociatedUser")]
        public long UserId { get; set; }
        public virtual User AssociatedUser { get; set; }

        public string IP { get; set; }

        public bool IsBlocked { get; set; }
    }
}
