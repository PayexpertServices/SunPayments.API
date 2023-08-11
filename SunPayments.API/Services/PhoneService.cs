﻿using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

        public HttpResponseMessage Confirm(string data,long reference_id)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"api/v1/referenceIds/{reference_id}/phones/2f/confirm")
            {
                Content=new StringContent(data,Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response=_httpClient.Send(request);

            return response;
        }
    }
}