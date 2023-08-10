using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Logging
{
    public class LogBaseModel
    {
        [Required]
        public DateTime CreatedAt { get; set; }

        public long CreatedBy { get; set; }
    }
}