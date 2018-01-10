namespace Resolver.Models.Responses
{
    /// <summary>
    /// This interface describes a general response.
    /// Can be an HTTP response, a SysCall response. Each with their own serialization. 
    /// </summary>
    public interface IResponse<TPayload>
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
        TPayload Payload { get; }
    }
}