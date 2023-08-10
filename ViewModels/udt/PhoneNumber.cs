using System.ComponentModel.DataAnnotations;

namespace UserManagement.ViewModels.udt
{
    public class PhoneNumber : BaseModel
    {
        [Key]
        public long PhoneNumberId { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumberValue { get; set; }
        public long CountryId { get; set; }
        public long PhoneNumberTypeId { get; set; }
        public long? PersonId { get; set; }
        public long? BusinessId { get; set; }
    }
}
