namespace Resolver.Models.Responses
{
    public class GeneralResponse<TResponse> : IResponse<TResponse>
    {
        public GeneralResponse(TResponse payload, int statusCode = 1, string errorMessage = "")
        {
            Payload = payload;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
        
        public TResponse Payload { get; }
        public int StatusCode { get; }
        public string ErrorMessage { get; }
    }
}