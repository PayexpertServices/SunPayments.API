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

        public HttpResponseMessage Confirm(string data,long reference_id, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/v1/referenceIds/{reference_id}/phones/2f/confirm")
            {
                Content=new StringContent(data,Encoding.UTF8, "application/json")
            };

            HeaderAdd(headers,request);

            HttpResponseMessage response=_httpClient.Send(request);

            return response;
        }

        private void HeaderAdd(Dictionary<string, string> headers,HttpRequestMessage requestMessage)
        {
            foreach (var header in headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }
        }
    }
}
