using System.Net;

namespace SunPayments.API.DTOs
{
    public class HttpErrorResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string ReasonPhrase { get; }
        public string Content { get; }

        public HttpErrorResponseException(HttpStatusCode statusCode, string reasonPhrase, string content)
            : base($"HTTP error response: {statusCode} - {reasonPhrase}")
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
            Content = content;
        }
    }
}
