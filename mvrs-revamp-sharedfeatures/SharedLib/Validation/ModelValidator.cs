//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;




//namespace SharedLib.Validation
//{
//    public class ModelValidator
//    {
//        public static bool TryValidate(object @object, out ValidationErrorResponse results)
//        {
//            var context = new ValidationContext(@object, serviceProvider: null, items: null);
//            var _validationResults = new List<ValidationResult>();

//            results = new ValidationErrorResponse();
//            bool isValid = Validator.TryValidateObject(
//                @object, context, _validationResults,
//                validateAllProperties: true
//            );

//            results.results = _validationResults;
//            results.summary = "";

//            foreach (var item in _validationResults)
//                results.summary += item.ErrorMessage + Environment.NewLine;

            

//            return isValid; 
            
//        }

//        public static bool TryValidateByDbContext(object @object, DbContext dbContext, out ValidationErrorResponse results)
//        {
//            var context = new ValidationContext(@object, serviceProvider: null, items: null);
//            var _validationResults = new List<ValidationResult>();

//            results = new ValidationErrorResponse();
//            results.results = _validationResults;
//            results.summary = "";

//            foreach (var item in _validationResults)
//                results.summary += item.ErrorMessage + Environment.NewLine;

//            bool isValid = Validator.TryValidateObject(
//                @object, context, _validationResults,
//                validateAllProperties: true
//            );

//            return isValid;
//        }
//    }
//}
