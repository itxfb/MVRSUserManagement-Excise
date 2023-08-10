using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Validation
{
    public class ValidationErrorResponse
    {
        public ICollection<ValidationResult> results { get; set; }
        public string summary { get; set; }
    }
}
