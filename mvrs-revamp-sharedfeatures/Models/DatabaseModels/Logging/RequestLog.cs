using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Logging
{
    public class RequestLog : BaseModel
    {
        [Key]
        public long Id { get; set; }
        public string TraceId { get; set; }

        //----Signup/Login/AppFunction/Get
        [Required]
        public string RequestCategory { get; set; }
        public string Method { get; set; }
        public string IP { get; set; }
        public string Agent { get; set; }
        public string ActionName { get; set; }
        public string Parameters { get; set; }
        public string Body { get; set; }

        //---Request, Response, InternalRequest, Other(should put desciption if Other) Use Enum RequestLogTypes
        [Required]
        public string LogType { get; set; }
        public string Json { get; set; }
        public bool IsExceptionResponse { get; set; }
        //public DateTime CreatedDate { get; set; }
        //--Project/App/Caller Name
        public string LogBySource { get; set; }
        //--if need to use against UserID, Token or any other entity then add table name or general name
        public string RefType { get; set; }
        //--Value for ref type
        public string RefValue { get; set; }
    }
}
