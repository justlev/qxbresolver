namespace Resolver.Models.Responses
{
    /// <summary>
    /// Response of the API.
    /// We want the Data, and error message + error code if something went wrong.
    /// Can be used for Console, Web, or any other consumer.
    /// </summary>
    /// <typeparam name="TContent">Payload Type of the response.</typeparam>
    public interface IResponse<TContent>
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
        TContent Content { get; }
    }
}