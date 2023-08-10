using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class GlobalRight : BaseModel
    {
        [Key]
        public long GRightId { get; set; }

        [Required]
        [StringLength(50)]
        public string GRightName { get; set; }

        [Required]
        [StringLength(20)]
        public string GRightNameAbbr { get; set; }

        [Required]
        [StringLength(1024)]
        public string GRightDescription { get; set; }

        [Required]
        public bool IsOnResourceLevel { get; set; }
    }
}
