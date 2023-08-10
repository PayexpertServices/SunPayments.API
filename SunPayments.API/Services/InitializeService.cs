using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SunPayments.API.Services
{
    public class InitializeService
    {
        private readonly HttpClient _httpClient;

        private bool BypassAllCertificate(object _sender, X509Certificate _cert, X509Chain _chain, System.Net.Security.SslPolicyErrors _error)
        {
            return true;
        }

        public InitializeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(BypassAllCertificate);
        }

        public HttpResponseMessage EncryptedPayload(object data)
        {

            //response.Headers.GetValues("X-Challenge").ToString();
            var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/signups/payPointMvp/initialize")
            {
                Content = new StringContent((string)data, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = _httpClient.Send(request);

            return response;


        }
       
    }
}
