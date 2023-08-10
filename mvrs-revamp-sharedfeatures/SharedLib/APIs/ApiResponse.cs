using System;

namespace SharedLib.APIs
{
    public enum ApiResponseType
    {
        SUCCESS = 0,
        FAILED = 1,
        EXCEPTION = 2,
        VALIDATION_ERROR = 3,
        NOT_FOUND = 404,
        UN_AUTHORIZED = 401
    }

    public class ApiResponse
    {
        public ApiResponseType status { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public static ApiResponse GetApiResponse(ApiResponseType status, object data, string message)
        {
            return new ApiResponse()
            {
                status = status,
                data = data,
                message = message,
            };
        }

        public static ApiResponse GetExceptionGenericResponse(ApiResponseType status, string TraceId)
        {
            return new ApiResponse()
            {
                status = status,
                message = $"Error: There is some error. Please contact System Administrator. ErrorID = {TraceId}",
            };
        }
        public static ApiResponse GetExceptionResponse(ApiResponseType status, object data, string message, string details, Exception ex, string TraceId)
        {
            if (status == ApiResponseType.EXCEPTION && ex != null)
            {
                return new ApiResponse()
                {
                    status = status,
                    data = data,
                    message = $"Error: There is some error. Please contact System Administrator. ErrorID = {TraceId}",
                };
            }

            return new ApiResponse()
            {
                status = status,
                data = data,
                message = message,
            };
        }

        public static ApiResponse GetValidationErrorResponse(ApiResponseType status, object data, string message, string details, SharedLib.Validation.ValidationErrorResponse validationResults)
        {
            return new ApiResponse()
            {
                status = status,
                data = data,
                //message = message,
                message = "Validation Errors",
                //details = details
            };
        }
    }


    public class ApiResponseCommons {

        
        public static string GetExceptionMessage (System.Exception ex, string TraceID)
        {

            return $"Error: There is some error. Please contact System Administrator. ErrorID = {TraceID}";
        }
    }

    
}
