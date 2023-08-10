using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Logging
{
    public class ILog: BaseModel
    {
        [Key]
    public long LogId { get; set; }
        
    public int LogLevel { get; set; }
    public int EventId { get; set; }
    public string Message { get; set; }
    public string ActionName { get; set; }
    public string Parameters { get; set; }
    public string Exception{ get; set; }
    public bool IsException { get; set; }
    //public DateTime CreatedDate { get; set; }

        public string JsonFormat { get; set; }
        public string TraceId { get; set; }

        public string LogType { get; set; }

    }
}
