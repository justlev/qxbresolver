namespace Resolver.Models.Responses
{
    public class GeneralResponse<ContentType> : IResponse<ContentType>
    {
        public GeneralResponse(ContentType payload, int statusCode = 0, string errorMessage = "")
        {
            Content = payload;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
        
        public ContentType Content { get; }
        public int StatusCode { get; }
        public string ErrorMessage { get; }
    }
}