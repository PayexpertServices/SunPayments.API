using Org.BouncyCastle.Crypto.Parameters;
using SunPayments.API.DTOs;
using SunPayments.API.Key;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

namespace SunPayments.API.Services
{
    public class PublickeyService
    {
        private readonly HttpClient _httpClient;

        public PublickeyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> GetPublicKey()
        {

            var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/security/publicKey");

            HttpResponseMessage response = _httpClient.Send(request);

            return response;
        }
    }
}
