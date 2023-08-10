using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class WhitelistedClientLog : BaseModel
    {
        [Key]
        public long WhitelistedClientLogId { get; set; }

        [ForeignKey("WhitelistedClient")]
        public long WhitelistedClientId { get; set; }
        public virtual WhitelistedClient WhitelistedClient { get; set; }

        [ForeignKey("AssociatedUser")]
        public long UserId { get; set; }
        public virtual User AssociatedUser { get; set; }

        public string IP { get; set; }

        public bool IsBlocked { get; set; }
    }
}
