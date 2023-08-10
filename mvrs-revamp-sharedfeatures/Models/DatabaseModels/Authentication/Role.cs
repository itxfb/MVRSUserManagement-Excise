using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels.Authentication
{
    public class Role : BaseModel
    {
        [Key]
        public long RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleNameAbbr { get; set; }

        [Required]
        [StringLength(1024)]
        public string RoleDescription { get; set; }
    }
}
