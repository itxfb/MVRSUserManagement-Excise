using Models.DatabaseModels.Authentication;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels
{
    public class BaseModel : IModel
	{
        protected BaseModel()
        {
            CreatedAt = DateTime.Now;
        }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        public long CreatedBy { get; set; }
        public virtual User User { get; set; }

        public DateTime? ModifiedAt { get; set; }

        [ForeignKey("Modifier")]
        public long? ModifiedBy { get; set; }
        public virtual User Modifier { get; set; }
    }
}
