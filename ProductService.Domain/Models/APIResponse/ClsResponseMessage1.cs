namespace ProductService.Domain.Models.APIResponse;


    public class ClsResponseMessage1
    {
        public bool IsSuccess { get; set; }

        public string? ResponseCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ClsResponseMessage1 Success(string?  message = null, string? responseCode = null)
        {
            return new ClsResponseMessage1
            {
                IsSuccess = true,
                ResponseCode = responseCode ?? "00",
                Message = message ?? "Operation successful"
            };
        }

        public static ClsResponseMessage1 Failure(string message, string? responseCode = null)
        {
            return new ClsResponseMessage1
            {
                IsSuccess = false,
                ResponseCode = responseCode ?? "99",
                Message = message
            };
        }
    }
    

