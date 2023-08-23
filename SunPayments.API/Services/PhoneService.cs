using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SunPayments.API.Services
{
    public class PhoneService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PhoneService> _logger;

        private bool BypassAllCertificate(object _sender, X509Certificate _cert, X509Chain _chain, System.Net.Security.SslPolicyErrors _error)
        {
            return true;
        }

        public PhoneService(HttpClient httpClient, ILogger<PhoneService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(BypassAllCertificate);
            
        }

        public HttpResponseMessage Confirm(string data,long reference_id, IHeaderDictionary headers)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/v1/referenceIds/{reference_id}/phones/2f/confirm")
            {
                Content=new StringContent(data,Encoding.UTF8, "application/json")
            };

            ControlHeaders(request, headers);

            HttpResponseMessage response=_httpClient.Send(request);

            return response;
        }

        private IHeaderDictionary ControlHeaders(HttpRequestMessage request, IHeaderDictionary headers)
        {
            var publicKeyHash = headers.FirstOrDefault(x => x.Key == "X-User-Public-Key-Hash");
            var timeStamp = headers.FirstOrDefault(x => x.Key == "X-Timestamp");
            var signature = headers.FirstOrDefault(x => x.Key == "X-Signature");
            var challenge = headers.FirstOrDefault(x => x.Key == "X-Challenge");

            if (publicKeyHash.Key is null)
            {
                _logger.LogInformation("X-User-Public-Key-Hash" + " " + "can not find!");
            }
            else
            {
                request.Headers.Add(publicKeyHash.Key.ToString(), publicKeyHash.Value.ToString());
                _logger.LogInformation(publicKeyHash.Key + " " + "added to header section");
            }

            if (timeStamp.Key is null)
            {
                _logger.LogInformation("X-Timestamp" + " " + "can not find!");
            }
            else
            {
                request.Headers.Add(timeStamp.Key.ToString(), timeStamp.Value.ToString());
                _logger.LogInformation(timeStamp.Key + " " + "added to header section");
            }

            if (signature.Key is null)
            {
                _logger.LogInformation("X-Signature" + " " + "can not find!");
            }
            else
            {
                request.Headers.Add(signature.Key.ToString(), signature.Value.ToString());
                _logger.LogInformation(signature.Key + " " + "added to header section");
            }

            if (challenge.Key is null)
            {
                _logger.LogInformation("X-Challenge" + " " + "can not find!");
            }
            else
            {
                request.Headers.Add(challenge.Key.ToString(), challenge.Value.ToString());
                _logger.LogInformation(challenge.Key + " " + "added to header section");
            }

            return headers;
        }

    }
}
