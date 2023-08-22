using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;

namespace SunPayments.API.Services
{
    public class PhoneService
    {
        private readonly HttpClient _httpClient;

        private bool BypassAllCertificate(object _sender, X509Certificate _cert, X509Chain _chain, System.Net.Security.SslPolicyErrors _error)
        {
            return true;
        }

        public PhoneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(BypassAllCertificate);
        }

        public HttpResponseMessage Confirm(string data,long reference_id, IHeaderDictionary headers)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/v1/referenceIds/{reference_id}/phones/2f/confirm")
            {
                Content=new StringContent(data,Encoding.UTF8, "application/json")
            };

            foreach (var header in headers)
            {
                if (header.Key.Contains("X-User-Public-Key-Hash") || header.Key.Contains("X-Timestamp") || header.Key.Contains("X-Signature") || header.Key.Contains("X-Challenge"))
                    request.Headers.Add(header.Key.ToString(), header.Value.ToString());
            }

            HttpResponseMessage response=_httpClient.Send(request);

            return response;
        }
        
    }
}
