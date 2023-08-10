using System;
using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels.Logging
{
    public class SqlExceptionLog : BaseModel
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }
        public int ErrorNumber { get; set; }
        public int ErrorState { get; set; }
        public int ErrorSeverity { get; set; }
        public int ErrorLine { get; set; }

        public string ErrorProcedure { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorDateTime { get; set; }
    }
}
