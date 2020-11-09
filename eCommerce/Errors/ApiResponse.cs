namespace eCommerce.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Wraps all controller responses in order to format them 
        /// </summary>
        /// <param name="statusCode">the response status code</param>
        /// <param name="message">an optional message</param>
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        /// <summary>
        /// Specifies some default error messages according with predefined response
        /// status codes
        /// </summary>
        /// <param name="statusCode">the status codes to display a message for</param>
        /// <returns>the message specific to a status code</returns>
        private static string GetDefaultMessageForStatusCode(in int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 =>
                    "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _ => null
            };
        }
    }
}