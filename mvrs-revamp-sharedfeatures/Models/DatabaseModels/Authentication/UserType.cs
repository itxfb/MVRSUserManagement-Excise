using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Authentication
{
    public class UserType : BaseModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public new long? CreatedBy { get; set; }
    }
}
