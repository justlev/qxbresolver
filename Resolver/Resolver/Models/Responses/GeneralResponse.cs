namespace Resolver.Models.Responses
{
    public class GeneralResponse<TResponse> : IResponse<TResponse>
    {
        public GeneralResponse(TResponse payload, int statusCode = 0, string errorMessage = "")
        {
            Content = payload;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
        
        public TResponse Content { get; }
        public int StatusCode { get; }
        public string ErrorMessage { get; }
    }
}