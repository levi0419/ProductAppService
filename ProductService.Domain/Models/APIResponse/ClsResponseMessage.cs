namespace ProductService.Domain.Models.APIResponse;

    public class ClsResponseMessage<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public string? ResponseCode { get; set; }
        public T? Data { get; set; }

        // Create a success response with optional custom message
        public static ClsResponseMessage<T> Success(T data, string? message = null, string? responseCode = null)
        {
            return new ClsResponseMessage<T>
            {
                IsSuccess = true,
                ResponseCode = responseCode ?? "00",
                Message = message ?? "Operation successful",
                Data = data
            };
        }

        // Create a failure response with required custom message
        public static ClsResponseMessage<T> Failure(string message, T? data = default, string? responseCode = null)
        {
            return new ClsResponseMessage<T>
            {
                IsSuccess = false,
                ResponseCode = responseCode ?? "99",
                Message = message,
                Data = data
            };
        }
    }