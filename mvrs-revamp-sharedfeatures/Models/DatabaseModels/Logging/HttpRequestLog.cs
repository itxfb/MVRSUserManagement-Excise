using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Logging
{
    public class HttpRequestLog : BaseModel
    {
        [Key]
        public long Id { get; set; }
        public string Method { get; set; }
        public string ClientIP { get; set; }
        public string Path { get; set; }
        public string RequestHeaders { get; set; }
        public string ResponseHeaders { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public int ResponseStatusCode { get; set; }
        public bool IsExceptionRaised { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string TraceId { get; set; }
    }
}
