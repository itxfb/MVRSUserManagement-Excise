using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Logging
{
    public class Log : BaseModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string TraceId { get; set; }
        [Required]
        public string LogType { get; set; }
        [Required]
        public string Source { get; set; }
        public string Parameters { get; set; }
        [Required]
        public string Message { get; set; }
        public string StackTrace { get; set; }
        //public DateTime CreatedDate { get; set; }
        public string RefType { get; set; }
        public string RefValue { get; set; }

    }
}
