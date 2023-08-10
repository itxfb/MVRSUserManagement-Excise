using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels
{
    public class ProfileBaseModel
	{
        protected ProfileBaseModel()
        {
            CreatedAt = DateTime.Now;
        }

        [Required]
        public DateTime CreatedAt { get; set; }

        public long MicroServiceUserId { get; set; }

        [ForeignKey("MicroService")]
        public long? MicroServiceId { get; set; }
        public virtual MicroService MicroService { get; set; }
    }
}
