using System.ComponentModel.DataAnnotations;

namespace UserManagement.ViewModels.udt
{
    public class BaseModel : IModel
    {
        protected BaseModel()
        {
            CreatedAt = DateTime.Now;
        }

        [Required]
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
